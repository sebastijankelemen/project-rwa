let timerInterval;
let elmt;


addControlStartEvents("stopwatch-start", "stopwatch-stop");
addControlStopEvents("stopwatch-stop", "stopwatch-start");

function addControlStartEvents(className, endClassName) {
    const elements = document.getElementsByClassName(className);

    for (let element of elements) {

        let startTime;
        let elapsedTime = 0;

        element.addEventListener("click", function()
        {
            const row = element.closest("tr");
            const totalTime = row.getElementsByClassName("total-time-duration")[0];

            if (timerInterval) {
                clearInterval(timerInterval);
                if (elmt.style.display === "none") {
                    elmt.style.display = "inline-block"
                }       
            }

            startTime = Date.now() - elapsedTime;

            timerInterval = setInterval(function printTime() {
                elapsedTime = Date.now() - startTime;
                totalTime.innerHTML = timeToString(elapsedTime);
            }, 10);

            if (element.style.display != "none") {
                element.style.display = "none"
                const endButton = row.getElementsByClassName(endClassName)[0];
                endButton.style.display = "inline-block"
            }
           

            elmt = element;
        });
    }
}

function addControlStopEvents(className, startClassName) {
    const elements = document.getElementsByClassName(className);

    for (let element of elements) {
        element.addEventListener("click", function () {
           
            if (timerInterval) {
                clearInterval(timerInterval);
                const row = element.closest("tr");
                const startButton = row.getElementsByClassName(startClassName)[0];
                startButton.style.display = "inline-block"
                element.style.display = "none";
            }
        });
    }
}

function timeToString(time) {
    let diffInHrs = time / 3600000;
    let hh = Math.floor(diffInHrs);

    let diffInMin = (diffInHrs - hh) * 60;
    let mm = Math.floor(diffInMin);

    let diffInSec = (diffInMin - mm) * 60;
    let ss = Math.floor(diffInSec);

    let diffInMs = (diffInSec - ss) * 100;
    let ms = Math.floor(diffInMs);

    let formattedMM = mm.toString().padStart(2, "0");
    let formattedSS = ss.toString().padStart(2, "0");
    let formattedMS = ms.toString().padStart(2, "0");

    return `${formattedMM}:${formattedSS}:${formattedMS}`;
}