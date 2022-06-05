$('#ingredientInput').on('keyup',  (e) => {
        if (e.which == 188 || e.which == 13) {

        let currentValue = $('#ingredientInput').val();
        const current = document.querySelector("#ingredientInput");

        if (currentValue.charCodeAt("/")) {
            currentValue = currentValue.replace(/\n/g, '');
        }
        currentValue = currentValue.replace(/,/g, '');
        
        var list = document.getElementById('ingredientList');
        var li = document.createElement("li");
        var input = document.createElement("input");
        input.type = "text";
        input.hidden = true;
        input.setAttribute("asp-for", "Ingredients")
        input.setAttribute("value", currentValue);

        li.classList.add("ingredientInputItem", "badge", "rounded-pill", "ingredientPills");
        
        li.appendChild(document.createTextNode(currentValue));
        li.appendChild(input)
        list.prepend(li);

        //for text area you have to clear like this 
        current.value = "";
    }
})