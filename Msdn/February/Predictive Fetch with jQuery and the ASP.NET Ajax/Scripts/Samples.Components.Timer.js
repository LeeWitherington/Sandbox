/// <reference name="MicrosoftAjax.js" />
/// <reference path="Samples.Components.Timer.js" />

// 
// Samples.Components.Timer
//

Type.registerNamespace('Samples.Components');


// Class ctor
// This code gets called when you instantiate this class
Samples.Components.Timer = function Samples$Components$Timer(expires, userCallback, shouldContinue) {
    // Calls the base ctor, if any
    Samples.Components.Timer.initializeBase(this);

    // Initializes the private members
    this._shouldContinue = false;
    if (typeof (shouldContinue) !== 'undefined') {
        this._shouldContinue = shouldContinue;
    }
    this._expires = expires;
    this._raiseTickDelegate = Function.createDelegate(this, this._raiseTick);
    this._userCallback = userCallback;
    this._timer = null;
}

// PROPERTY:: expires: int (milliseconds)
function Samples$Components$Timer$get_expires() { 
    if (arguments.length !== 0) throw Error.parameterCount();
    return this._expires;
}
function Samples$Components$Timer$set_expires(value) {
    var e = Function._validateParams(arguments, [{name: 'value', type: Int}]);
    if (e) throw e;

    this._expires = value;
}

// PROPERTY:: isActive: bool 
function Samples$Components$Timer$get_isActive() { 
    if (arguments.length !== 0) throw Error.parameterCount();
    return (this._timer !== null);
}



// METHOD:: stop()
function Samples$Components$Timer$stop(){
   this._stopTimer();
}

// METHOD:: start()
function Samples$Components$Timer$start(){
    this._startTimer();
}


///////                     ///////
///////  PRIVATE members    ///////
///////                     ///////


function Samples$Components$Timer$_startTimer() {
    this._timer = window.setTimeout(this._raiseTickDelegate, this._expires);
}

function Samples$Components$Timer$_stopTimer() {
    this.dispose(); 	
}

function Samples$Components$Timer$_dispose() {
    if (this._timer !== null) {
        window.clearTimeout(this._timer);
        this._timer = null;
    }
}

function Samples$Components$Timer$_raiseTick() {
    if (this._userCallback !== null)
        this._userCallback();
    if (this._shouldContinue)
        this._startTimer();
}

// Class PROTOTYPE
Samples.Components.Timer.prototype = 
{
    get_isActive:  Samples$Components$Timer$get_isActive,
    get_expires:   Samples$Components$Timer$get_expires,
    set_expires:   Samples$Components$Timer$set_expires,
    dispose:       Samples$Components$Timer$_dispose,
    stop:          Samples$Components$Timer$stop,
    start:         Samples$Components$Timer$start,
    _raiseTick:    Samples$Components$Timer$_raiseTick,
    _startTimer:   Samples$Components$Timer$_startTimer,
    _stopTimer:    Samples$Components$Timer$_stopTimer
}

// It may actually lack a real IDisposable implementation! No way to check it
Samples.Components.Timer.registerClass('Samples.Components.Timer', null, Sys.IDisposable);

// For script files to be processed correctly by the ScriptManager control, 
// each file must include a call to the Sys.Application.notifyScriptLoaded method 
// at the end of the file. 
// This call notifies the application that the file has finished loading.
if (typeof (Sys) !== 'undefined') 
    Sys.Application.notifyScriptLoaded();
