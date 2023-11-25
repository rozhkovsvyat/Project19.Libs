# Project 19 : Libraries

<img align="right" width="100" height="100" src="https://github.com/rozhkovsvyat/Tools.Wpf/assets/71471748/e06a3e12-64d0-4b9f-90a4-5fd61f8a9db9">

**#net7.0.10 #efcore7.0.13**

Библиотеки проекта Phonebook

> :eye_speech_bubble: https://www.nuget.org/profiles/rozhkovsvyat

---

### MODELS

* **Contacts** -- модель контакта, интерфейс поставщика контактов
* **Contacts.Test** -- реализация тестового поставщика (лист с задержкой)
* **Contacts.Db** -- реализация поставщика из базы данных
* **Contacts.Factory** -- интерфейс фабрики контактов, простая (3) и случайная (3/5/8) реализации
* **Identity** -- модели идентификации, интерфейс работы с идентификацией
* **Identity.Mongo** -- реализация идентификации Mongo, проверка здоровья
* **Identity.Factory** -- интерфейс фабрики аккаунтов, простая (admin/default) и конфигурируемая реализации

---

### SERVICES

* **Api** -- интерфейс апи-сервиса, интерфейс работы с токеном
* **ApiContacts** -- реализация сервиса поставщика контактов, проверка здоровья
* **ApiIdentity** -- реализация сервиса идентификации, проверка здоровья
* **Initializator** -- интерфейс инициализации сервиса
* **UrlButtonService** -- интерфейс сервиса кнопок-ссылок
* **UrlButtonService.SocialBar** -- реализация панели социальных сетей
* 
---

> [!NOTE]
> :leaves: [Использует MongoDbCore3.1.12](https://www.nuget.org/packages/AspNetCore.Identity.MongoDbCore)
>
> :fireworks: [Использует JwtBearer7.0.13](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer)
