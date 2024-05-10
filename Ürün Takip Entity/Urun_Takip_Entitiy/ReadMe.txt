Bu program Visual studio üzerinden C# ile yazılmıştır. Bu bir örnek programdır ve amacı bir beyaz eşya mağazasının elindeki stokların ve müşterilerin kayıtlarını tutmaktır.

1- Öncelikle MSSQL üzerinden bir veritabanı oluşturulup, müşteriler için bir tablo oluşturulmuştur. Oluşturulan bu tablo yeni müşterileri 
kaydeder ve kaydedilen müşterilerin çeşitli sorgularının yapılmasını sağlar. Müşterilerin verileri Ad, Soyad, Bakiye ve Sehir adı altındaki
ilgili sütunlara kaydedilir. 

2- Daha sonra ise winform üzerinden "Müşteriler" adında bir form oluşturuldu. Kaydet, Sil ve Güncelle butonları eklendi. Ayrıca oluşturulan veritabanı ile form bağlantısı entity framework ile kurulup ilgili veritabanı sütununda değişiklik yapmak için textboxlar müşteriler formuna eklendi. Bu aşamadan sonra kullanıcı müşteriler ile iglili verileri form aracılığı ile veritabanına kaydedebilir. Akabinde halihazırda kaydedilen müşterilerin verileri, program üzerinden güncellenebilir ve silinebilir. 

3-Daha sonra ise kaydedilen müşterilerin verileri bir dataGridView yardımı ile ekranda gösterilir. Bu aşamadan sonra kullanıcının seçtiği satır ve sütun ilgili veriler ilgili textboxlarda gösterilir. Bu sayede kullanıcının yanlış bir kaydı değiştirmesinin ve silmesinin önüne geçilir.

4-İkinic bölümde ise bir iststistik formu oluşturuldu bu formun amacı firmanın halihazırda sahip olduğu müşteri sayısı, ürün sayısı,toplam kasa tutarı vb verileri, kullanıcı her işlem yaptığında güncel tutmak ve yeniden hesaplamaktır. kod kısmında, istatistik formu veritabanına bağlanır ve veritabanındaki tabloların ilgili verileri ile işlemler yapar daha sonra ise bu sonuçları ilgili panelin içindeki label da gösterir.

5- Bu program ve veritabanı örnek olarak yapılmıştır. Programda sadece müşteri tablosu form üzerinden değiştirilebilir. Geri kalan bütün tablolar test amacı ile SQL tarafında oluşturulmuştur.
