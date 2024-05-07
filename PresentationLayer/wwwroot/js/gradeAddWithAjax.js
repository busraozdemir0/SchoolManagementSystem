$(document).ready(function () {
    $("#btnSave").click(function (event) {
        event.preventDefault(); // Sayfanin yeniden yuklenmesi engellenir.

        var addUrl = app.Urls.gradeAddUrl;
        var redirectUrl = app.Urls.lessonAddUrl;
        var gradeAddDto = {
            Name: $("input[id=gradeName]").val() // id'si gradeName olan input'un degerini alir.
        }

        // JSON.stringify fonksiyonu kullanilarak bu nesne JSON formatinda bir dizeye cevrilir.
        var jsonData = JSON.stringify(gradeAddDto); 
        console.log(jsonData);

        $.ajax({
            url: addUrl,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: jsonData,
            success: function (data) {
                setTimeout(function () {
                    window.location.href = redirectUrl; // İslem basarili oldugunda redirectUrl'de tanimlanan sayfaya(lesson) donecek.
                }, 1000); // 1 sn sonra sayfa yenilenecek.
            },
            error: function () {
                toast.error("Bir hata oluştu", "Hata");
            }
        });
    });
});