const tarea = document.querySelector('#tarea');

tarea.addEventListener('keyup', (e) => {
    e.preventDefault()
    if (e.code == "Comma" || e.code == "Enter") {
        const thevalue = tarea.value;
        console.log(thevalue)
    }
})


// google also add's a span and it is inside a table
// I don't know if I even need the table and anyting else but this section