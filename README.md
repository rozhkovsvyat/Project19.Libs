# Project 19 : Libraries

<img align="right" width="100" height="100" src="https://github.com/rozhkovsvyat/Tools.Wpf/assets/71471748/e06a3e12-64d0-4b9f-90a4-5fd61f8a9db9">

**#net7.0.10**

Библиотеки проекта Phonebook

> :eye_speech_bubble: https://www.nuget.org/profiles/rozhkovsvyat

---

### MODELS

* **Contacts** -- модель контакта, интерфейс поставщика контактов
* **Contacts.Test** -- реализация тестового поставщика (лист с задержкой)
* **Contacts.Db** -- реализация поставщика из базы данных / [EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore)
* **Contacts.Factory** -- интерфейс фабрики контактов, простая (3) и случайная (3-5-8) реализации
* **Identity** -- модели идентификации, интерфейс работы с идентификацией
* **Identity.Mongo** -- реализация идентификации / [MongoDbCore](https://www.nuget.org/packages/AspNetCore.Identity.MongoDbCore) + [JwtBearer](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer)
* **Identity.Factory** -- интерфейс фабрики аккаунтов, простая (admin/default) и конфигурируемая реализации

---

### SERVICES

* **Api** -- интерфейс апи-сервиса, интерфейс работы с токеном
* **Api.ApiContacts** -- реализация сервиса апи-поставщика контактов / [Http](https://www.nuget.org/packages/Microsoft.Extensions.Http)
* **Api.ApiIdentity** -- реализация сервиса апи-идентификации / [Http](https://www.nuget.org/packages/Microsoft.Extensions.Http)
* **Initializator** -- интерфейс инициализации сервиса
* **UrlButtonService** -- интерфейс сервиса кнопок-ссылок
* **UrlButtonService.SocialBar** -- реализация панели социальных сетей
