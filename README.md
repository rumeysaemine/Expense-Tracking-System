# Expense Tracking System
Bu proje, saha personelinin masraf taleplerini sisteme iletmesini ve yöneticilerin bu talepleri onaylamasını sağlayan bir harcama takip sistemidir. Bu sistem sayesinde:

- Saha personeli, masraflarını anında kaydedebilir ve geri ödeme talebinde bulunabilir.
- Yöneticiler, gelen talepleri onaylayıp reddedebilir.
- Evrak/fiş toplama zorunluluğu ortadan kalkar, süreçler dijitalleşir ve ödemeler gecikmeden yapılır.


## 🔧 Teknolojiler
- ASP.NET Core Web API
- MediatR (CQRS pattern)
- Entity Framework Core
- PostgreSQL
- JWT Authentication & Authorization


## 📄 Kullanılabilir API Endpoint'leri
### Auth
* `POST /api/Auth/login` → Kullanıcının e-posta ve şifresiyle giriş yapmasını sağlar. Başarılı giriş durumunda JWT token döner.

### Personel Endpoints
- `POST /api/Expenses` → Yeni bir masraf talebi oluşturur
- `POST /api/Expenses/upload` → Masraf belgesi (fatura, fiş vb.) yükler.
- `GET /api/Expenses/my-expenses` → Giriş yapan personelin tüm masraf taleplerini listeler.
- `GET /api/Expenses/my-expenses/by-status`→ Belirli bir durumdaki (Pending, Approved, Rejected) masraf taleplerini getirir.

### Admin Endpoints
* `GET /api/Expenses/all` → (Admin) Tüm personellerin masraf taleplerini listeler.
* `GET /api/Expenses/add-personel` → (Admin) Yeni bir personel kullanıcı oluşturur.
* `POST /api/Expenses/{id}/approve` → (Admin) Belirtilen masraf talebini onaylar.
* `POST /api/Expenses/{id}/reject` → (Admin) Belirtilen masraf talebini reddeder.


## 🛠️ Kurulum

1.  **Depoyu Klonlayın:**

    ```bash
    git clone [https://github.com/rumeysaemine/Expense-Tracking-System.git](https://github.com/rumeysaemine/Expense-Tracking-System.git)
    cd Expense-Tracking-System
    ```

2.  **Bağımlılıkları Yükleyin:**

    Projenin gerektirdiği NuGet paketlerini yüklemek için aşağıdaki komutu çalıştırın:

    ```bash
    dotnet restore
    ```

3.  **Veritabanı Bağlantı Bilgilerini Yapılandırın:**

    API projesi içerisindeki `appsettings.json` dosyasını açın ve `ConnectionStrings` bölümündeki `DefaultConnection` alanını kendi PostgreSQL veritabanı bağlantı bilgilerinize göre güncelleyin.

    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Host=localhost;Database=ExpenseDb;Username=postgres;Password=senin_sifren"
    }
    ```

4.  **Migration'ları Uygulayın:**

    Veritabanı şemasını oluşturmak veya güncellemek için Entity Framework Core Migration'larını uygulayın. 

    ```bash
    dotnet ef database update --project ExpenseTracking.Infrastructure --startup-project ExpenseTracking.API
    ```

    Bu komut, `ExpenseDb` veritabanını oluşturacak ve gerekli tabloları yapılandıracaktır. Herhangi bir hata alırsanız, Entity Framework Core araçlarının yüklü olduğundan emin olun (`dotnet tool install --global dotnet-ef`).

5.  **Uygulamayı Başlatın:**

    API projesini çalıştırmak için aşağıdaki komutu kullanın:

    ```bash
    dotnet run --project ExpenseTracking.API
    ```

