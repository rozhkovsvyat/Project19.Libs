# Project 19 : Libraries
#nuget #net7.0.10

see https://www.nuget.org/profiles/rozhkovsvyat

Библиотеки проекта Phonebook

----------------------------------------------------------
МОДЕЛИ
----------------------------------------------------------

Project19.Models.Contacts - модель контакта, интерфейс поставщика контактов

Project19.Models.Contacts.Test - реализация тестового поставщика контактов (лист, имитация задержки)

Project19.Models.Contacts.Db - реализация поставщика контактов из базы данных (EFCore)

Project19.Models.Contacts.Factory - интерфейс фабрики контактов, простая реализация (возвращает 3 записи), случайная реализация (возвращает 3/5/8 записей)

Project19.Models.Identity - 

Project19.Models.Identity.Factory

Project19.Models.Identity.Mongo

----------------------------------------------------------
СЕРВИСЫ
----------------------------------------------------------

Project19.Services.Api

Project19.Services.Api.ApiContacts

Project19.Services.Api.ApiIdentity

Project19.Services.Initializator

Project19.Services.UrlButtonService

Project19.Services.UrlButtonService.SocialBar
