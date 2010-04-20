var _backgroundElement = document.createElement("div");
var _elem = null;


function disableUI(dom) {
    //alert(_elem.getName());
    dom.appendChild(_backgroundElement);
    if (true) {

        _backgroundElement.style.display = '';
        _backgroundElement.style.position = 'fixed';
        _backgroundElement.style.left = _elem.offsetLeft.toString() + "px";
        _backgroundElement.style.top = _elem.offsetTop.toString() + "px";

        _backgroundElement.style.width = _elem.clientWidth.toString() + "px";
        _backgroundElement.style.height = _elem.clientHeight.toString() + "px";
        _backgroundElement.style.zIndex = 10000;
        _backgroundElement.style.backgroundColor = "white";
        _backgroundElement.style.opacity = "0.8";
        _backgroundElement.style.filter = 'alpha(opacity=80)';
    }
    else
    {
        //_backgroundElement.style.display = 'none';
    }
}
