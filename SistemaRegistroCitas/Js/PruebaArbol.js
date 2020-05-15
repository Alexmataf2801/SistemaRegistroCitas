function OnTreeClick(evt) {
    var Arbol = document.getElementById('RaizArbol');
    var F = evt.target;
    var Parent = GetParentByTagName("ul", Arbol);
    var nxtSibling = Parent.nextSibling;


}

function GetParentByTagName(parentTagName, childElementObj) {
    var parent = childElementObj.parentNode;
    while (parent.tagName.toLowerCase() != parentTagName.toLowerCase()) {
        parent = parent.parentNode;
    }
    return parent;
}

$(document).ready(function () {
    $('#DivArbol input[type="checkbox"]').on('change', function () {
        checkParent($(this));
    });

    function checkParent(element) {
        if (element.prop('checked')) {
            var parent = element.parent().parent().find('> input[type="checkbox"]');

            if (parent.length) {
                parent.prop('checked', true);
                checkParent(parent);
            }
        }
    }
});