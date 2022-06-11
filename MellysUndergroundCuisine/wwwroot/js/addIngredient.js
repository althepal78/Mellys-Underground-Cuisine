$('#Name').on('keyup', function (e) {
    if (e.which == 188 || e.which == 13) {
        console.log("hit");

        let currentValue = $('#Name').val();
        const current = document.querySelector("#Name");

        if (currentValue.charCodeAt("/")) {
            currentValue = currentValue.replace(/\n/g, '');
        }
        currentValue = currentValue.replace(/,/g, '');

        let dishId = document.getElementById('DishId').value;

        let ingredient = {
            DishId: dishId,
            Name: currentValue
        };

        $.ajax({
            type: 'post',
            url: '/Admin/AddIngredient',
            data: ingredient,
            success: function (data) {
                var list = document.getElementById('ingredientList');

                var item = document.createElement("li");
                item.classList.add("ingredientInputItem", "badge", "bg-black", "text-secondary");
                item.appendChild(document.createTextNode(currentValue));

                var span = document.createElement("span");
                span.classList.add( "badge", "bg-black", "text-white");
                span.value = "X";


                item.appendChild(span);

                list.appendChild(item);

                current.value = "";

                toastr.success('Successfully Added The Ingredient');
            },
            error: function (xhr, resp, text) {
                console.log(xhr);
                toastr.error(xhr.responseText);
                current.value = "";
            }
        })


    }
})