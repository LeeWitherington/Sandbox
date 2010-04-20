// 
// Samples.MarkupBuilder 
//

Type.registerNamespace('Samples');


// Class ctor
// This code gets called when you instantiate this class
Samples.MarkupBuilder = function Samples$MarkupBuilder() 
{
    // Calls the base ctor, if any
    Samples.MarkupBuilder.initializeBase(this);
    
    // Initializes the private members
    this._header = "";
    this._footer = "";
    this._itemTemplate = "";
}
Samples.MarkupBuilder = function Samples$MarkupBuilder(header, footer) 
{
    // Calls the base ctor, if any
    Samples.MarkupBuilder.initializeBase(this);
    
    // Initializes the private members
    this._header = header;
    this._footer = footer;
    this._itemTemplate = "";
}

// PROPERTY:: header: string 
function Samples$MarkupBuilder$get_header() { 
    if (arguments.length !== 0) throw Error.parameterCount();
    return this._header;
}
function Samples$MarkupBuilder$set_header(value) {
    var e = Function._validateParams(arguments, [{name: 'value', type: String}]);
    if (e) throw e;

    this._header = value;
}

// PROPERTY:: footer: string 
function Samples$MarkupBuilder$get_footer() { 
    if (arguments.length !== 0) throw Error.parameterCount();
    return this._footer;
}
function Samples$MarkupBuilder$set_footer(value) {
    var e = Function._validateParams(arguments, [{name: 'value', type: String}]);
    if (e) throw e;

    this._footer = value;
}

// PROPERTY:: itemTemplate: string 
function Samples$MarkupBuilder$get_itemTemplate() { 
    if (arguments.length !== 0) throw Error.parameterCount();
    return this._itemTemplate;
}
function Samples$MarkupBuilder$set_itemTemplate(value) {
    var e = Function._validateParams(arguments, [{name: 'value', type: String}]);
    if (e) throw e;

    this._itemTemplate = value;
}


// METHOD:: bind()
function Samples$MarkupBuilder$bind(data, callback) {
   var temp = this._generate(data, callback);
   return temp;
}

// METHOD:: loadHeader()
function Samples$MarkupBuilder$loadHeader(domElement) {
   var temp = domElement.innerHTML;
   this._header = temp;
}

// METHOD:: loadFooter()
function Samples$MarkupBuilder$loadFooter(domElement) {
   var temp = domElement.innerHTML;
   this._footer = temp;
}

// METHOD:: loadItemTemplate()
function Samples$MarkupBuilder$loadItemTemplate(domElement) {
   var temp = domElement.innerHTML;
   this._itemTemplate = temp;
}

///////                     ///////
///////  PRIVATE members    ///////
///////                     ///////


function Samples$MarkupBuilder$_generate(data, itemCallback) 
{
    var pattern = /#\w+/g;  // Finds all #word occurrences 

    var _builder = new Sys.StringBuilder(this._header);
    
    for(i=0; i<data.length; i++)
    {
        var dataItem = data[i];
        var template = this._itemTemplate;

        var matches = template.match(pattern); 
        for (j=0; j<matches.length; j++)
        {
            var text = matches[j];
            var memberName = text.slice(1);
            
            // Invoke a callback to further modify the data to be bound
            var memberData = dataItem[memberName];
            var temp = memberData;
            if (itemCallback !== undefined)
            {
                temp = itemCallback(memberName, dataItem);
            }
                
            template = template.replace(matches[j], temp); 
        }
        
        _builder.append(template);
    }
    
    _builder.append(this._footer);
    
    
    // Return the markup
    var markup = _builder.toString();
    return markup;
}


// Class PROTOTYPE
Samples.MarkupBuilder.prototype = 
{
    get_header:         Samples$MarkupBuilder$get_header,
    set_header:         Samples$MarkupBuilder$set_header,
    get_footer:         Samples$MarkupBuilder$get_footer,
    set_footer:         Samples$MarkupBuilder$set_footer,
    get_itemTemplate:   Samples$MarkupBuilder$get_itemTemplate,
    set_itemTemplate:   Samples$MarkupBuilder$set_itemTemplate,
    bind:               Samples$MarkupBuilder$bind,
    _generate:          Samples$MarkupBuilder$_generate,
    loadHeader:         Samples$MarkupBuilder$loadHeader,
    loadFooter:         Samples$MarkupBuilder$loadFooter,
    loadItemTemplate:   Samples$MarkupBuilder$loadItemTemplate
}

Samples.MarkupBuilder.registerClass('Samples.MarkupBuilder');



