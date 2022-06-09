$('#Name').on('keyup', function (e) {
    if (e.which == 188 || e.which == 13) {
        console.log("hit");

        let currentValue = $('#Name').val();
        const current = document.querySelector("#Name");

        if (currentValue.charCodeAt("/")) {
            currentValue = currentValue.replace(/\n/g, '');
        }

        let dishId = document.getElementById('DishId').value;
        currentValue = currentValue.replace(/,/g, '');
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
                item.classList.add("ingredientInputItem", "badge", "rounded-pill", "ingredientPills");
                item.appendChild(document.createTextNode(currentValue));
                list.appendChild(item);

                current.value = "";
            },
            error: function (xhr, resp, text) {
                console.log(xhr);
            }
        })


    }
})