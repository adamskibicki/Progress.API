param location string

@allowed([
  'dev'
  'test'
  'prod'
])
param environmentName string

@description('Name used as a part of resources name when possible')
@minLength(5)
@maxLength(11)
param appName string = 'progress'

param keyVaultName string


resource keyVault 'Microsoft.KeyVault/vaults@2022-07-01' existing = {
  name: keyVaultName
}


var resourceTags = {
  Environment: environmentName
}

var uniqueSuffix = uniqueString(resourceGroup().id)

module sa 'storageAccount.bicep' = {
  name: 'storageDeployment'
  params: {
    location: location
    name: '${environmentName}sa${uniqueSuffix}'
    sku: (environmentName == 'prod') ? 'Standard_GRS' : 'Standard_LRS'
    tags: resourceTags
  }
}

module webApp 'webApp.bicep' = {
  name: 'webAppDeployment'
  params: {
    location: location
    name: '${environmentName}-${appName}-web-app-${uniqueSuffix}'
    tags: resourceTags
    jwtToken: keyVault.getSecret('jwtToken')
  }
}

output webAppNameHostName string = webApp.outputs.webAppHostName
