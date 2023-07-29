param location string

@allowed([
  'dev'
  'test'
  'prod'
])
param environmentName string

@description('Specifies whether Azure Resource Manager is permitted to retrieve secrets from the key vault.')
param enabledForTemplateDeployment bool = false

@description('Specifies the Azure Active Directory tenant ID that should be used for authenticating requests to the key vault. Get it by using Get-AzSubscription cmdlet.')
param tenantId string = subscription().tenantId

@description('Specifies the object ID of a user, service principal or security group in the Azure Active Directory tenant for the vault. The object ID must be unique for the list of access policies. Get it by using Get-AzADUser or Get-AzADServicePrincipal cmdlets.')
param objectId string

param sqlAdminName string

@secure()
param sqlAdminPassword string

@secure()
param jwtToken string

var resourceTags = {
  Environment: environmentName
}

var uniqueSuffix = uniqueString(resourceGroup().id)

resource keyVault 'Microsoft.KeyVault/vaults@2023-02-01' = {
  name: '${environmentName}-${uniqueSuffix}'
  location: location
  tags: resourceTags
  properties: {
    enabledForTemplateDeployment: enabledForTemplateDeployment
    sku: {
      family: 'A'
      name: 'standard'
    }
    accessPolicies: [
      {
        objectId: objectId
        permissions: {
          secrets: [
            'get'
          ]
        }
        tenantId: tenantId
      }
    ]
    tenantId: tenantId
  }
}

resource secretSqlAdminName 'Microsoft.KeyVault/vaults/secrets@2023-02-01' = {
  parent: keyVault
  name: 'sqlAdminName'
  properties: {
    value: sqlAdminName
  }
}

resource secretSqlAdminPassword 'Microsoft.KeyVault/vaults/secrets@2023-02-01' = {
  parent: keyVault
  name: 'sqlAdminPassword'
  properties: {
    value: sqlAdminPassword
  }
}

resource secretJwtToken 'Microsoft.KeyVault/vaults/secrets@2023-02-01' = {
  parent: keyVault
  name: 'jwtToken'
  properties: {
    value: jwtToken
  }
}
