# Project 19 : Libraries
#nuget #net7.0.10

Библиотеки проекта Phonebook

> https://www.nuget.org/profiles/rozhkovsvyat

### MODELS

* Contacts - модель контакта, интерфейс поставщика контактов

* Contacts.Test - реализация тестового поставщика (лист с задержкой)

* Contacts.Db - реализация поставщика из базы данных (efcore)
  
* Contacts.Factory - интерфейс фабрики контактов, простая (3) и случайная (3/5/8) реализации

* Identity - модели аккаунта и роли, интерфейс поставщика идентификации, формы, опции токена

* Identity.Factory - интерфейс фабрики аккаунтов, простая (2) и конфигурируемая реализации

* Identity.Mongo

### SERVICES

* Api

* ApiContacts

* ApiIdentity

* Initializator

* UrlButtonService

* UrlButtonService.SocialBar
