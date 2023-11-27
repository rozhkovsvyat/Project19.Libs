# Project 19 : Libraries

<img align="right" width="100" height="100" src="https://github.com/rozhkovsvyat/Project19.Libs/assets/71471748/ffe2175c-9c6a-48b6-912f-606db74eb851">
<img align="right" width="100" height="100" src="https://github.com/rozhkovsvyat/Project19.Libs/assets/71471748/5edac1a8-4909-4213-9c07-7adc1b9b4947">

**#net7.0.10**

Библиотеки проекта Phonebook

> :eye_speech_bubble: https://www.nuget.org/profiles/rozhkovsvyat

---

### MODELS

* **Contacts** -- модель контакта, интерфейс поставщика контактов
* **Contacts.Test** -- тестовый поставщик контактов (лист с задержкой)
* **Contacts.Db** -- поставщик контактов из базы данных / [EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore)
* **Contacts.Factory** -- интерфейс и реализации фабрики контактов
* **Identity** -- интерфейс и модели идентификации
* **Identity.Mongo** -- идентификация / [MongoDbCore](https://www.nuget.org/packages/AspNetCore.Identity.MongoDbCore) + [HealthChecks](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.HealthChecks) + [JwtBearer](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer)
* **Identity.Factory** -- интерфейс и реализации фабрики аккаунтов

---

### SERVICES

* **Api** -- интерфейсы сервиса апи
* **Api.ApiContacts** -- сервис поставщика контактов / [HttpClientFactory](https://www.nuget.org/packages/Microsoft.Extensions.Http)
* **Api.ApiIdentity** -- сервис идентификации / [HttpClientFactory](https://www.nuget.org/packages/Microsoft.Extensions.Http)
* **Initializator** -- инициализатор сервиса
* **UrlButtonService** -- интерфейс сервиса кнопок-ссылок
* **UrlButtonService.SocialBar** -- сервис панели социальных сетей

---

### WPF

* **Tools.RecipeFactory** -- [абстрактная фабрика объекта](https://github.com/rozhkovsvyat/Tools.RecipeFactory)
* **Tools.WPF** -- [инструменты разработки WPF](https://github.com/rozhkovsvyat/Tools.WPF)
