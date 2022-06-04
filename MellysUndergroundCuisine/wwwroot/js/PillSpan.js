const tarea = document.querySelector('#randomNumber');
const createParagraph = document.createElement("p")
const div = document.querySelector(".outside-class")

tarea.addEventListener('keyup', (e) => {
    e.preventDefault()
    if (e.code == "Comma" || e.code == "Enter") {
        const thevalue = tarea.value;
        createParagraph.append(thevalue)
        div.prepend(createParagraph)
    }
})


// gmail adds a whole div and inside that div a span with 2 more divs
/*
 <div class="justMadeDiv">
   <span class="justMadeSpan" email="theEmail" data-hovercard-id="email">
           <div translate="no" class="emailClass">email</div> this one actually usesthe email information
           <div class="closeButton"></div> this is for the close button 
           <input name="to" type="hidden" value="email" />
   </span>
 </div>
 */