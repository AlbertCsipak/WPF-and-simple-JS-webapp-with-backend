let array = [];
let connection = null;
getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:11111/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("CarCreated", (user, message) => {
        getdata();
    });

    connection.on("CarDeleted", (user, message) => {
        getdata();
    });

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
    await fetch('http://localhost:11111/car')
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

function remove(id) {
    fetch('http://localhost:11111/car/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function create() {
    let servicecost = document.getElementById('servicecost').value;
    let brandid = document.getElementById('brandid').value;
    let ownerid = document.getElementById('ownerid').value;
    let mechanicid = document.getElementById('mechanicid').value;
    let engineid = document.getElementById('engineid').value;


    fetch('http://localhost:11111/car', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { serviceCost: servicecost, brandId: brandid, ownerId: ownerid, engineCode:engineid,mechanicId:mechanicid})
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}