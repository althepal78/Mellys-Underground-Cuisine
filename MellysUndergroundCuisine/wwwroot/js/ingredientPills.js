$('#ingredientInput').on('keyup', function (e) {
  if (e.which == 188) {
    let current = $('#ingredientInput').val();
    current = current.replace(/,/g, '');
    let list = document.getElementById('ingredientList');
    let li = document.createElement("li");
    li.classList.add("ingredientInputItem", "badge", "rounded-pill", "ingredientPills");
    li.appendChild(document.createTextNode(current));
    list.prepend(li);
    $(this).val("");
  }
})