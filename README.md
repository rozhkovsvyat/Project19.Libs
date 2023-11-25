# Project 19 : Libraries
#nuget #net7.0.10

Библиотеки проекта Phonebook

> :eye_speech_bubble: https://www.nuget.org/profiles/rozhkovsvyat

### MODELS

* **Contacts** > модель контакта, интерфейс поставщика контактов

* **Contacts.Test** > реализация тестового поставщика (лист с задержкой)

* **Contacts.Db** > реализация поставщика из базы данных (efcore)
  
* **Contacts.Factory** > интерфейс фабрики контактов, простая (3) и случайная (3/5/8) реализации

* **Identity** > модели аккаунта и роли, опции токена, формы, интерфейс работы с идентификацией

* **Identity.Mongo** > реализация идентификации на основе MongoDB, проверка работоспособности

* **Identity.Factory** > интерфейс фабрики аккаунтов, простая (admin/default) и конфигурируемая реализации

### SERVICES

* **Api** > интерфейс апи-сервиса, интерфейс работы с токеном

* **ApiContacts** > реализация сервиса поставщика контактов, проверка работоспособности

* **ApiIdentity** > реализация сервиса идентификации, проверка работоспособности

* **Initializator** > интерфейс инициализации сервиса

* **UrlButtonService** > интерфейс сервиса кнопок-ссылок

* **UrlButtonService.SocialBar** > реализация панели социальных сетей
