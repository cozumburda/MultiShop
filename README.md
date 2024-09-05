

MultiShop - E-Ticaret Alışveriş Sitesi (Microservice)
Projenin Temel Amacı
MultiShop E-Ticaret projesi, kullanıcıların oturum açarak veya ziyaretçi olarak siteye giriş yapmalarını sağlayan, kapsamlı bir e-ticaret alışveriş platformudur. Kullanıcılar, ürünler içerisinden diledikleri ürünleri arayabilir, listeleyebilir ve sepetlerine ekleyebilir sepet içerisinde güncelleme yapabilirler. Alışveriş sürecinin sonunda, kullanıcılar siparişlerini güvenle oluşturabilir, fatura ve sevk adresi bilgilerini güncelleyebilirler. Site yöneticisi ile mesajlaşabilirler. Siparişlerini kullanıcı panelinden takip edebilirler.

Bu projede, tüm mikroservisler ASP.NET Core Web API 6.0 ile yazıldı ve MVC tarafında tüketildiği bir mimariye sahiptir. Her mikroserviste, farklı mimari ve tasarım desenleri uygulanmıştır. Kullanılan mimariler arasında Tek Katmanlı, N Katmanlı ve Onion Mimari yer almıştır. Repository, CQRS ve Mediator tasarım desenleri uygulamada kullanılmıştır. Ayrıca, 5 farklı veritabanı ile uygulamanın içeriği zenginleştirilmiştir, bu da esneklik ve ölçeklenebilirlik sağlamaktadır.

Kullanılan Teknolojiler
Asp.Net Core 6.0
Asp.Net Web API
Docker
MSSQL
MongoDb
Redis NoSQL
PostgreSQL
Dapper ORM
IdentityServer4
RabbitMQ
SignalR
RapidApi
Json Web Token
Html
Css
JavaScript
Ajax
Bootstrap
DBeaver
Postman
Swagger
Google Cloud Storage
Onion Architecture
CQRS Design Pattern
Mediator Design Pattern
Repository Design Pattern
Ocelot Gateway
MailKit
Mikroservisler - Veritabanları
Basket - Docker Redis
Cargo - Docker MSSQL
Catalog - MongoDb
Comment - Docker MSSQL
Discount - Local MSSQL Dapper
Images - Local SQL - Google Cloud Storage
Message - PostgreSQL
Order - Docker MSSQL
IdentityServer4 - Docker MSSQL
Payment
RabbitMQ
SignalR
RapidApi
Ocelot
Öne Çıkan Özellikler
Ürünler kategorilerine göre listelenebilir.
Mevcut dil seçenekleri ile menüler istenilen dilde kullanılabilir.
Sepete eklenen ürün sepette güncellenebilir.
Sepette indirim kuponu uygulanabilir.
Sepet onaylandıktan sonra sevk ve fatura adresleri oluşturulabilir, güncellenebilir.
Kullanıcı site yöneticisi ile kullanıcı panelinden mesajlaşabilir, siparişlerini görebilir.
Site yöneticisi admin panelinden tüm güncellemeleri yapabilir, istatistikleri görebilir, yorumları kontrol edebilir, ürün araması yaparak ürünlerin güncel fiyatlarına api üzerinden ulaşabilir.
Site yöneticisi kargo adreslerini kullanıcının belirlediği adres olarak güncelleyebilir. Tüm siparişleri kontrol edebilir.
