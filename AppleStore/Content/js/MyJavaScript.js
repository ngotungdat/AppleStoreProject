/*Phan trang*/
$(function () {
    $('.btnTrang').click(function () {
        $(".top_brand_left").hide();
        var pageCount = $(this).attr("data-sotrang");
        $("." + pageCount).show();
    });
});
/*End phan trang*/


//Hieu ung go to cart
