param name string
param location string
param tags object
@secure()
param jwtToken string

resource appServicePlan 'Microsoft.Web/serverfarms@2022-09-01' = {
  name: '${name}-plan'
  location: location
  tags: tags
  sku: {
    name: 'F1'
  }
}

resource appServiceApp 'Microsoft.Web/sites@2022-09-01' = {
  name: name
  location: location
  tags: tags
  properties: {
    serverFarmId: appServicePlan.id
    httpsOnly: true
    siteConfig: {
      appSettings: [
        {
          name: 'jwtToken'
          value: jwtToken
        }
      ]
    }
  }
}

output webAppHostName string = appServiceApp.properties.defaultHostName
