# Project 19 : Libraries

<img align="right" width="100" height="100" src="https://github.com/rozhkovsvyat/Project19.API/assets/71471748/7f85c4b6-61f6-4f61-a801-b9f9e291cfb2">
<img align="right" width="100" height="100" src="https://github.com/rozhkovsvyat/Project19.API/assets/71471748/e8fc4568-0abd-4931-8213-e2061f5e6274">

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
* **Identity.Mongo** -- реализация идентификации / [MongoDbCore](https://www.nuget.org/packages/AspNetCore.Identity.MongoDbCore) + [HealthChecks](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.HealthChecks) + [JwtBearer](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer)
* **Identity.Factory** -- интерфейс фабрики аккаунтов, простая (admin-default) и конфигурируемая реализации

---

### SERVICES

* **Api** -- интерфейс апи-сервиса, интерфейс работы с токеном
* **Api.ApiContacts** -- реализация сервиса апи-поставщика контактов / [HttpClientFactory](https://www.nuget.org/packages/Microsoft.Extensions.Http)
* **Api.ApiIdentity** -- реализация сервиса апи-идентификации / [HttpClientFactory](https://www.nuget.org/packages/Microsoft.Extensions.Http)
* **Initializator** -- интерфейс инициализации сервиса
* **UrlButtonService** -- интерфейс сервиса кнопок-ссылок
* **UrlButtonService.SocialBar** -- реализация панели социальных сетей
