// SignalR ba?lant?s? olu?turuluyor
var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7061/SignalRHub").build();

// Gönderme butonu etkisizle?tiriliyor
document.getElementById("sendbutton").disabled = true;

// Sunucudan 'ReceiveMessage' olay?n? dinleyen fonksiyon
connection.on("ReceiveMessage", function (user, message) {
    // ?u anki zaman bilgileri al?n?yor
    var currentTime = new Date();
    var currentHour = currentTime.getHours();
    var currentMinute = currentTime.getMinutes();

    // Yeni bir liste ö?esi (li) ve içinde kullan?c? ad?yla birlikte ileti olu?turuluyor
    var li = document.createElement("li");
    var span = document.createElement("span");
    span.style.fontWeight = "bold";
    span.textContent = user;
    li.appendChild(span);
    // ?leti ve zaman bilgisi ekleniyor
    li.innerHTML += ` :${message} - ${currentHour}:${currentMinute}`;
    // Mesaj listesine ekleniyor
    document.getElementById("messagelist").appendChild(li);
});

// SignalR ba?lant?s? ba?lat?l?yor
connection.start().then(function () {
    // Gönderme butonu etkinle?tiriliyor
    document.getElementById("sendbutton").disabled = false;
}).catch(function (err) {
    // Ba?latma hatas? varsa hata konsola yazd?r?l?yor
    return console.error(err.toString());
});

// Gönderme butonuna t?klan?nca çal??acak fonksiyon
document.getElementById("sendbutton").addEventListener("click", function (event) {
    // Kullan?c? ad? ve ileti al?n?yor
    var user = document.getElementById("userinput").value;
    var message = document.getElementById("messageinput").value;
    // Sunucuya 'SendMessage' metoduyla kullan?c? ad? ve ileti gönderiliyor
    connection.invoke("SendMessage", user, message).catch(function (err) {
        // Gönderme hatas? varsa hata konsola yazd?r?l?yor
        return console.error(err.toString());
    });
    // Sayfa yenilenmesini engellemek için varsay?lan davran?? engelleniyor
    event.preventDefault();
});
