$(".collapse-click").click(function () {
    $(this).nextAll(".collapse").collapse('toggle');
});

$(".delete-click").click(function () {
    const parentIndex = $(".delete-click").attr('id');
    deleteItem(parentIndex);
});


const uri = "/api/WorkHours";

function deleteItem(id) {
    fetch(`${uri}/Delete/${id}`, {
        method: 'DELETE'
    })
        .then(() => $(".delete-click").parent().parent().remove())
        .catch(error => console.error('Unable to delete item.', error));
}