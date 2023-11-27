# Project 19 : Libraries

<img align="right" width="100" height="100" src="https://github.com/rozhkovsvyat/Project19.API/assets/71471748/eebef49c-3357-4aca-8cb4-0bef3471d52b">
<img align="right" width="100" height="100" src="https://github.com/rozhkovsvyat/Project19.API/assets/71471748/e8fc4568-0abd-4931-8213-e2061f5e6274">

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

### TOOLS

> :link: [**Tools.RecipeFactory**](https://github.com/rozhkovsvyat/Tools.RecipeFactory)
> 
> :link: [**Tools.WPF**](https://github.com/rozhkovsvyat/Tools.WPF)
