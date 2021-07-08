![](Images/Calloway.png)

Kodluyoruz ve Apsiyon iş birliği ile yapılan **Apsiyon .Net Core Bootcamp**'nin bitirme projesi olarak **Housing Estate Management** adlı uygulamayı geliştirdim.  Projenin içerisinde İki farklı kullanıcı tipi bulunmakta ve bu kullanıcı tipine göre belli özellikler barındırmakta. 

### 1-Admin/Yönetici Rolü 

* :ear: ​**Duyuru İşlemleri : ** Yönetici **Housing Estate Management** aracılığı ile duyuru ekleyebilir, silebilir, düzenleyebilir.
* :house: **Site ile İlgili İşlemler :** Yönetici  **Housing Estate Management** aracılığı ile siteye blok ekleyebilir, silebilir, düzenleyebilir aynı zamanda siteye daire ekleyebilir, silebilir, düzenleyebilir.
* :man: **Kullanıcı İşlemleri :** Yönetici  **Housing Estate Management** aracılığı ile kullanıcı ekleyebilir, silebilir, düzenleyebilir.
* :dollar:  **Finansal İşlemler** : Yönetici  **Housing Estate Management** aracılığı ile bütün borçları görüntüleyebilir, ekleyebilir, silebilir, düzenleyebilir, bütün ödenmiş borçları görüntüleyebilir, gider türü ekleyebilir, silebilir, düzenleyebilir, toplu olarak veya tek bir daire’yi borçlandırabilir. 
* :package:  **Mesaj işlemleri :** Yönetici  **Housing Estate Management**  gelen kutusu ’nu görüntüleyebilir, giden kutusu ‘nu görüntüleyebilir, sitede ki istediği kişiye mesaj gönderebilir. 

### 2- Kullanıcı Rolü

* :ear:: **Duyuru İşlemleri :** Kullanıcı **Housing Estate Management** aracılığı ile duyuruları görüntüleyebilir.

* :dollar: **Finansal İşlemler :** Kullanıcı **Housing Estate Management** aracılığı ile kendisine ait ödenmemiş borçları görüntüleyebilir, ödeyebilir, ödediği borçları görüntüleyebilir.

* :package:**Mesaj İşlemleri :** Kullanıcı **Housing Estate Management** aracılığı ile  gelen Kutusu ’nu görüntüleyebilir, giden kutusunu görüntüleyebilir ve yöneticiye mesaj gönderebilir.

  

  ## :computer: Projenin Kurulumu

   Proje’yi çalıştırmak için MongoDb ve Microsoft Sql Server’ın bilgisayarınızda yüklü olması gerekmektedir. Bu kurulumları tamamladıktan sonra veritabanlarımızın yerel sunucumuzda oluşmasını sağlamak için projemizi açıyoruz. Başlangıç projemizi **HousingEstateManagement.Web** olarak belirledikten sonra package manager console’umuzda varsayılan projemizi **HousingEstateManagement.Data** olarak belirliyor ve **update-database** komutunu giriyoruz.Bu işlemden sonra veritabanımız yerel sunucumuz içerisinde oluşuyor. Son olarak projeyi çalıştırmak için solution ayarlarından **Multiple Startup Project**  olarak **HousingEstateManagement.Payment.API** ve **HousingEstateManagement.Web** projelerini seçiyoruz. Uygulamayı çalıştırırken **HousingEstateManagement.Service** içindeki **PaymentAPIService** üzerinden yerel sunucunuzu kendi kullandığınız api için  portları ile değiştirmeniz gerekmektedir 

  #### Admin olarak giriş yapmak için gerekli olan bilgiler: 

  **Email:**admin@admin.com

  **Şifre**:admin123

![](Images/AnaSayfa.PNG)

![](Images/Borçlar Listesi.PNG)

![](Images/Daire Liste.PNG)

![](Images/Kullanıcı Ekleme.PNG)

![](Images/Login.PNG)

<h2> 🛠 &nbsp;Kullanılan Teknolojiler</h2>

<img alt="GIF" src="https://i.pinimg.com/originals/e4/26/70/e426702edf874b181aced1e2fa5c6cde.gif" />

<table style"float:right;">
  <tr>
    <td><img src="https://img.shields.io/badge/-JavaScript-black?style=flat&logo=javascript"/></td>
    <td><img src="https://img.shields.io/badge/-HTML5-E34F26?style=flat&logo=html5&logoColor=white"></td>
    <td><img src="https://img.shields.io/badge/-Identity-5C2D91?style=flat&logo=.net&logoColor=white"/></td>
  </tr>
  <tr>
    <td><img src="https://img.shields.io/badge/-FluentValidation-CC2927?style=flat-square&logo=.net&logoColor=ffffff"/></td>
    <td><img src="https://img.shields.io/badge/-AutoMapper-5C2D91?style=flat&logo=.net&logoColor=white"/</td>
    <td><img src="https://img.shields.io/badge/-EntityFramework-5C2D91?style=flat&logo=.net&logoColor=white"/><img src="https://img.shields.io/badge/-ASP.NET-5C2D91?style=flat&logo=.net&logoColor=white"/></td>
  </tr>
  <tr>
    <td><img src="https://img.shields.io/badge/-MongoDB-FCA121?style=flat&logo=mongodb"/><img src="https://img.shields.io/badge/-Github-black?style=flat&logo=github"/></td>
    <td> <img src="https://img.shields.io/badge/-Git-black?style=flat&logo=git"/></td>
    <td><img src="https://img.shields.io/badge/-json-02569B?style=flat&logo=json"/></td>
  </tr>
  <tr>
    <td><img src="https://img.shields.io/badge/-Bootstrap-563D7C?style=flat&logo=bootstrap"/></td>
 		<td><img src="https://img.shields.io/badge/-CSS3-1572B6?style=flat&logo=css3"/></td>
    <td><img src="https://img.shields.io/badge/-Sql%20Server-CC2927?style=flat-square&logo=microsoft-sql-server&logoColor=ffffff"/></td>
  </tr>
</table>




## :phone: İletişim

<img src="https://raw.githubusercontent.com/TanZng/TanZng/master/assets/hollor_knight3.gif" width="200"/>

 <details align="center">
   <summary><b> <samp> İletişime Geçin </samp></b></summary>
   <br>
   <samp>
   <b><h2 style="color: #fc6203">MAHMUT &nbsp; BAHA &nbsp; BAYAR</h2></b>
   <img src="https://raw.githubusercontent.com/TanZng/TanZng/master/assets/bonefire.gif" width="200"/>
     <br>
     Projenin Linki: <a href="https://github.com/bahabayar/HousingEstateManagement">Housing Estate Management</a>
     <br>
     Instagram: <a href="https://www.instagram.com/bahabayar/"> Instagram Hesabım</a>
     <br>
     Facebook: <a href="https://www.facebook.com/bahabayar/"> Facebook Hesabım</a>
     <br>
     Mail Adresim: <a href="#"> bahabayar@hotmail.com</a>
   </samp>
 </details>


