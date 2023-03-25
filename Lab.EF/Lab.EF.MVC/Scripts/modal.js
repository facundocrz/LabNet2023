function deleteModalShipper(shipperId, companyName) {
    $("#companyName").text(" " + companyName);

    $("#deleteShipperBtn").off("click").on("click", function() {
        window.location.href = "/Shippers/Delete/" + shipperId;
    });
}
$("a[data-bs-toggle='modal']").on("click", function() {
    let shipperId = $(this).data("shipperid");
    let companyName = $(this).data("companyname");
    deleteModalShipper(shipperId, companyName);
});

function deleteModalCategory(categoryId, categoryName) {
    $("#categoryName").text(" " + categoryName);

    $("#deleteCategoryBtn").off("click").on("click", function() {
        window.location.href = "/Categories/Delete/" + categoryId;
    });
}
$("a[data-bs-toggle='modal']").on("click", function() {
    let categoryId = $(this).data("categoryid");
    let categoryName = $(this).data("categoryname");
    deleteModalCategory(categoryId, categoryName);
});