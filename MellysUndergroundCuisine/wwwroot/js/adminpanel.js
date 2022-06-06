$('#ingredientInput').on('keyup', (e) => {
  if (e.which == 188 || e.which == 13) {
    console.log("hit");

        let currentValue = $('#ingredientInput').val();
        const current = document.querySelector("#ingredientInput");

        if (currentValue.charCodeAt("/")) {
            currentValue = currentValue.replace(/\n/g, '');
        }
        currentValue = currentValue.replace(/,/g, '');

        var list = document.getElementById('ingredientList');
        
        //var input = document.createElement("input");
        //input.type = "text";
        //input.hidden = true;
        //input.setAttribute("id", "Ingredients");
        //input.setAttribute("name", "Ingredients");
        //input.setAttribute("data-val", "true")
        //input.setAttribute("value", currentValue);

      var item = document.createElement("li");
      item.classList.add("ingredientInputItem", "badge", "rounded-pill", "ingredientPills");
      item.appendChild(document.createTextNode(currentValue));
      list.appendChild(item);
        //var span = document.createElement("span");
        //span.classList.add("ingredientInputItem", "badge", "rounded-pill", "ingredientPills");
        //span.appendChild(document.createTextNode(currentValue));
        //span.appendChild(input)
        //current.appendChild(span);

        //for text area you have to clear like this 
        current.value = "";
    }
})

$('#btnAddDish').on('click', function (e) {
  e.preventDefault();
  let listItems = $('#ingredientList li');
  let ingredientList = [];
  $.each(listItems, function (key, value) {
    ingredientList.push(value.innerHTML);
  })

  let data = {
    Dish_Name = $('#name').val();
    //all the other inputs
    Dish_Ingredients = ingredientList

  };

  //POST to your action with ajax or fetch or whatever you want
})