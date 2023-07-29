param location string
param name string
@allowed([
  'Standard_GRS'
  'Standard_LRS'
])
param sku string
param tags object

resource storageAccount 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: name
  location: location
  tags: tags
  sku: {
    name: sku 
  }
  kind: 'StorageV2'
  properties: {
    accessTier: 'Cool'
  }
}
