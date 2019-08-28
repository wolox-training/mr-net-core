const tempStorage = {}

const getValue = key => {
  const encodedKey = window.btoa(key)
  let encodedValue
  try {
    encodedValue = window.localStorage.getItem(encodedKey)
  } catch (e) {
    encodedValue = tempStorage[encodedKey]
  }
  const stringValue = encodedValue && window.atob(encodedValue)
  return stringValue && stringValue !== 'undefined' && JSON.parse(stringValue)
}

const setValue = (key, value) => {
  const encodedKey = window.btoa(key)
  const stringValue = JSON.stringify(value)
  const encodedValue = window.btoa(stringValue)
  try {
    window.localStorage.setItem(encodedKey, encodedValue)
  } catch (e) {
    tempStorage[encodedKey] = encodedValue
  }
}

const removeValue = key => {
  const encodedKey = window.btoa(key)
  try {
    window.localStorage.removeItem(encodedKey)
  } catch (e) {
    tempStorage[encodedKey] = undefined
  }
}

const LocalStorageService = {}

const defineProperty = (prop, defaultKey = '', tag = '') => {
  const capitalizedKey = `${prop[0].toUpperCase()}${prop.substring(1)}`
  LocalStorageService[`set${capitalizedKey}`] = (val, key = defaultKey) =>
    setValue(`@@TRAININGVUE:${prop}${tag}${key}`, val)
  LocalStorageService[`get${capitalizedKey}`] = (key = defaultKey) =>
    getValue(`@@TRAININGVUE:${prop}${tag}${key}`)
  LocalStorageService[`remove${capitalizedKey}`] = (key = defaultKey) =>
    removeValue(`@@TRAININGVUE:${prop}${tag}${key}`)
}

// ------------------------------ LOCAL STORAGE PROPERTIES ------------------------------
defineProperty('authToken')

export default LocalStorageService
