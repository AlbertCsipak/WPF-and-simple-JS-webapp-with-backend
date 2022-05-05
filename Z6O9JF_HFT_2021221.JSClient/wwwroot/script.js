let array = [];
let connection = null;
getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:11111/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.onclose(async () => {
        await start();
    });
    start();

}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:11111/')
        .then(x => x.json())
        .then(y => {
            array = y;
            console.log(array);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    array.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.vin + "</td><td>"
            + t.brandId + "</td><td>"
            + t.serviceCost + "</td><td>"
            + `<button type="button" onclick="remove(${t.vin})">Delete</button>`
            + "</td></tr>";
    });
}
