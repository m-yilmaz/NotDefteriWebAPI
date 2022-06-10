const API_URL = "https://localhost:5001/api/not";
let notlar = [];

function yeniNot() {
    const not = {
        id: 0,
        baslik: "Yeni Not",
        icerik: "",
        olusturulmaTarihi: null,
        guncellemeTarihi: null
    };

    $.ajax({
        type: "POST",
        url: API_URL,
        contentType: "application/json",
        data: JSON.stringify(not),
        success: function (data) {
            notListele();
        }
    });
}


function notListele() {
    $("#txtBaslik").hide();
    $("#txtIcerik").hide();
    $("#btnKaydet").hide();
    $("#btnSil").hide();
    $.ajax({
        type: "GET",
        url: API_URL,
        success: function (data) {
            notlar = data;
            $("#notList").html("");
            for (let i = 0; i < notlar.length; i++) {
                $("#notList").append(`
                    <button type="button"  class="list-group-item list-group-item-action" data-id="${notlar[i].id}" onclick="notGetir(${notlar[i].id})" >${notlar[i].baslik}</button>
                `);
            }
        }
    });
}


function notGetir(id) {
    $.ajax({
        type: "GET",
        url: API_URL + "/" + id,
        success: function (veri) {
            $("#txtBaslik").show();
            $("#txtIcerik").show();
            $("#btnKaydet").show();
            $("#btnSil").show();
            $("#txtBaslik").val(veri.baslik);
            $("#txtIcerik").val(veri.icerik);
            $("#btnKaydet").attr("data-id", veri.id);
            $("#btnSil").attr("data-id", veri.id);

            var seciliNot = $(`button[data-id="${id}"]`);
            var butunNotlar = $("#notList button");
            for (let i = 0; i < butunNotlar.length; i++) {
                $(butunNotlar[i]).removeClass("active");
            }
            seciliNot.addClass("active");
        }
    });
}

function notSil(){
    const id = $("#btnSil").attr("data-id");
    $.ajax({
        type: "DELETE",
        url: API_URL + "/" + id,
        success: function (data) {
            notListele();
        }
    });
}

function notDuzenle(){
    const id = $("#btnKaydet").attr("data-id");
    const not = {
        id: id,
        baslik: $("#txtBaslik").val(),
        icerik: $("#txtIcerik").val(),
        olusturulmaTarihi: null,
        guncellemeTarihi: null
    };
    $.ajax({
        type: "PUT",
        url: API_URL + "/" + id,
        contentType: "application/json",
        data: JSON.stringify(not),
        success: function (data) {
            notListele();
        }
    });
}

notListele();