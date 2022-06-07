$('#ingredientInput').on('keyup', (e) => {;
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

$('#btnAddDish').on('submit', function (e) {
  //e.preventDefault();
  let listItems = $('#ingredientList li');
  let ingredientList = [];
  $.each(listItems, function (key, value) {
    ingredientList.push(value.innerHTML);
  })

  //let data = {
  //  Dish_Name : $('#Dish_Name').val(),
  //  Dish_Information : $('#Dish_Information').val(),
  //  Dish_Price : $('#Dish_Price').val(),
  //  Dish_Quantity : $('#Dish_Quantity').val(),
  //  //Dish_FoodImage : $('#Dish_FoodImage')[0].files,
  //  //all the other inputs
  //  Dish_Ingredients : ingredientList
  //};

  let form = $('#frmAddIngredient')[0];
  console.log(form);
  let pageForm = new FormData(form);
  pageForm.append("Dish.Ingredients", ingredientList);
  console.log(pageForm.get("Dish.Name"));

  //$.ajax({
  //  type: "post",
  //  url: "/Admin/AddDish",
  //  data: pageForm,
  //  enctype: 'multipart/form-data',
  //  contentType: false,
  //  processData: false,
  //  success: function (d) {
  //    console.log(d);
  //  },
  //  error: function (xhr, resp, text) {
  //    console.log(xhr);
  //  }
  //})

  //POST to your action with ajax or fetch or whatever you want
})