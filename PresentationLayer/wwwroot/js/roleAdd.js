$(document).ready(function () {
    $("#btnSave").click(function (event) {
        event.preventDefault(); // Sayfanin yeniden yuklenmesi engellenir.

        var addUrl = app.Urls.roleAddUrl;
        var redirectUrl = app.Urls.userAddUrl;

        var roleAddDto = {
            Name: $("input[id=roleName]").val() // id'si roleName olan input'un degerini alir.
        }

        var jsonData = JSON.stringify(roleAddDto); // JSON.stringify fonksiyonu kullanilarak bu nesne JSON formatinda bir dizeye cevrilir.
        console.log(jsonData);

        $.ajax({
            url: addUrl,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: jsonData,
            success: function (data) {
                setTimeout(function () {
                    window.location.href = redirectUrl; // İslem basarili oldugunda redirectUrl tanimlandigi gibi kullanici sayfasina donecek
                }, 1000); // 1 sn sonra sayfa yenilenecek.
            },
            error: function () {
                toast.error("Bir hata oluştu", "Hata");
            }
        });
    });
});