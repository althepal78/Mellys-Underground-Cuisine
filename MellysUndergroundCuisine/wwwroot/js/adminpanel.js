$('#ingredientInput').on('keyup', (e) => {
    if (e.which == 188 || e.which == 13) {

        let currentValue = $('#ingredientInput').val();
        const current = document.querySelector("#ingredientInput");

        if (currentValue.charCodeAt("/")) {
            currentValue = currentValue.replace(/\n/g, '');
        }
        currentValue = currentValue.replace(/,/g, '');

        var list = document.getElementById('ingredientList');
        
        var input = document.createElement("input");
        input.type = "text";
        input.hidden = false;
        input.setAttribute("id", "Ingredients");
        input.setAttribute("name", "Ingredients");
        input.setAttribute("data-val", "true")
        input.setAttribute("value", currentValue);

        var li = document.createElement("li");
        li.classList.add("ingredientInputItem", "badge", "rounded-pill", "ingredientPills");
        li.appendChild(document.createTextNode(currentValue));
        li.appendChild(input)
        list.appendChild(li);

        //for text area you have to clear like this 
        current.value = "";
    }
})