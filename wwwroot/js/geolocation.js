function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition);
    } else {
        console.error("Geolocation is not supported by this browser.");
    }
}

function showPosition(position) {
    document.getElementById("latitude").value = position.coords.latitude;
    document.getElementById("longitude").value = position.coords.longitude;
    document.getElementById("getWeatherForm").submit();
}

document.addEventListener("DOMContentLoaded", function () {
    if (!localStorage.getItem("weatherDataLoaded")) {
        navigator.geolocation.getCurrentPosition(
            (position) => {
                localStorage.setItem("weatherDataLoaded", true);
                document.getElementById("latitude").value = position.coords.latitude;
                document.getElementById("longitude").value = position.coords.longitude;
                document.getElementById("getWeatherForm").submit();
            },
            (error) => {
                console.error("Error fetching location:", error);
            }
        );
    } else {
        localStorage.removeItem("weatherDataLoaded");
    }
});
