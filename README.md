<h3>MultiShop - E-Ticaret Alışveriş Sitesi (Microservice)</h3>
<h5>Projenin Temel Amacı</h5>
<p>MultiShop E-Ticaret projesi, kullanıcıların oturum açarak veya ziyaretçi olarak siteye giriş yapmalarını sağlayan, kapsamlı bir e-ticaret alışveriş platformudur. Kullanıcılar, ürünler içerisinden diledikleri ürünleri arayabilir, listeleyebilir ve sepetlerine ekleyebilir sepet içerisinde güncelleme yapabilirler. Alışveriş sürecinin sonunda, kullanıcılar siparişlerini güvenle oluşturabilir, fatura ve sevk adresi bilgilerini güncelleyebilirler. Site yöneticisi ile mesajlaşabilirler. Siparişlerini kullanıcı panelinden takip edebilirler.</p>
<p>
    Bu projede, tüm mikroservisler ASP.NET Core Web API 6.0 ile yazıldı ve MVC tarafında tüketildiği bir mimariye sahiptir. Her mikroserviste, farklı mimari ve tasarım desenleri uygulanmıştır. Kullanılan mimariler arasında Tek Katmanlı, N Katmanlı ve Onion Mimari yer almıştır. Repository, CQRS ve Mediator tasarım desenleri uygulamada kullanılmıştır. Ayrıca, 5 farklı veritabanı ile uygulamanın içeriği zenginleştirilmiştir, bu da esneklik ve ölçeklenebilirlik sağlamaktadır.
</p>
<h5>Kullanılan Teknolojiler</h5>
<ul>
    <li>Asp.Net Core 6.0</li>
    <li>Asp.Net Web API</li>
    <li>Docker</li>
    <li>MSSQL</li>
    <li>MongoDb</li>
    <li>Redis NoSQL</li>
    <li>PostgreSQL</li>
    <li>Dapper ORM</li>
    <li>IdentityServer4</li>
    <li>RabbitMQ</li>
    <li>SignalR</li>
    <li>RapidApi</li>
    <li>Json Web Token</li>
    <li>Html</li>
    <li>Css</li>
    <li>JavaScript</li>
    <li>Ajax</li>
    <li>Bootstrap</li>
    <li>DBeaver</li>
    <li>Postman</li>
    <li>Swagger</li>
    <li>Google Cloud Storage</li>
    <li>Onion Architecture</li>
    <li>CQRS Design Pattern</li>
    <li>Mediator Design Pattern</li>
    <li>Repository Design Pattern</li>
    <li>Ocelot Gateway</li>
    <li>MailKit</li>
</ul>
<h5>Mikroservisler - Veritabanları</h5>
<ul>
    <li>Basket - Docker Redis</li>
    <li>Cargo - Docker MSSQL</li>
    <li>Catalog - MongoDb</li>
    <li>Comment - Docker MSSQL</li>
    <li>Discount - Local MSSQL Dapper</li>
    <li>Images - Local SQL - Google Cloud Storage</li>
    <li>Message - PostgreSQL</li>
    <li>Order - Docker MSSQL</li>
    <li>IdentityServer4 - Docker MSSQL</li>
    <li>Payment</li>
    <li>RabbitMQ</li>
    <li>SignalR</li>
    <li>RapidApi</li>
    <li>Ocelot</li>
</ul>
<h5>Öne Çıkan Özellikler</h5>
<ul>
    <li>Ürünler kategorilerine göre listelenebilir.</li>
    <li>Mevcut dil seçenekleri ile menüler istenilen dilde kullanılabilir.</li>
    <li>Sepete eklenen ürün sepette güncellenebilir.</li>
    <li>Sepette indirim kuponu uygulanabilir.</li>
    <li>Sepet onaylandıktan sonra sevk ve fatura adresleri oluşturulabilir, güncellenebilir.</li>
    <li>Kullanıcı site yöneticisi ile kullanıcı panelinden mesajlaşabilir, siparişlerini görebilir.</li>
    <li>Site yöneticisi admin panelinden tüm güncellemeleri yapabilir, istatistikleri görebilir, yorumları kontrol edebilir, ürün araması yaparak ürünlerin güncel fiyatlarına api üzerinden ulaşabilir.</li>
    <li>Site yöneticisi kargo adreslerini kullanıcının belirlediği adres olarak güncelleyebilir. Tüm siparişleri kontrol edebilir.</li>            
</ul>
<h5>Ekran Görüntüleri :</h5>
![home](https://github.com/user-attachments/assets/48267a0a-144d-4521-9dfc-69b319b482ac)
![UI1](https://github.com/user-attachments/assets/db0b5557-1e3a-4065-9b28-c68df4d79de4)
![UI2](https://github.com/user-attachments/assets/4a644214-debf-4436-ba6e-6988d14ef198)
![UI3](https://github.com/user-attachments/assets/44c9c6ab-6739-43a9-9206-d90bb93bc185)
![UI4](https://github.com/user-attachments/assets/895f75e1-ca89-4b9c-8265-1c9f407b8eae)
<h5>Ekran Görüntüleri : Admin Paneli</h5>
![Admin1](https://github.com/user-attachments/assets/846dd647-9b15-46df-9c9f-0d914eace69f)
![Admin2](https://github.com/user-attachments/assets/4c4a0c37-3f7c-41f2-8496-76e1dc256c4d)
![Admin3](https://github.com/user-attachments/assets/43fad4f8-be2e-4051-a084-444ffd8f9d5f)
![Admin4](https://github.com/user-attachments/assets/afbc4467-88e3-499f-8789-e1f41d75262d)
![Admin5](https://github.com/user-attachments/assets/522ba749-c438-4237-ba21-73829c9dcdf4)
<h5>Ekran Görüntüleri : Kullanıcı Paneli</h5>
![UI1](https://github.com/user-attachments/assets/6f5004ee-a61d-4bb7-a0c7-f690aad2ea29)
![UI2](https://github.com/user-attachments/assets/09842608-7081-421b-ae5b-481381fb45b2)
