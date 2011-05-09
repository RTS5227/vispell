var image_width = 70;
var avatar_image_width = 50;
var avatar_small_image_width = 20;
var allow_chars = 140;



/************            LIBRARY FUNCTION              *********/

// Parses GET/POST/COOKIE data and sets global variables  
// 
// version: 903.421
// discuss at: http://phpjs.org/functions/parse_str
// +   original by: Cagri Ekin
// +   improved by: Michael White (http://getsprink.com)
// +    tweaked by: Jack
// +   bugfixed by: Onno Marsman
// %        note 1: Currently does not put variables in local scope.
// %        note 1: So use of second argument is required.
// *     example 1: var arr = {};
// *     example 1: parse_str('first=foo&second=bar', arr);
// *     results 1: arr == { first: 'foo', second: 'bar' }
// *     example 2: var arr = {};
// *     example 2: parse_str('str_a=Jack+and+Jill+didn%27t+see+the+well.', arr);
// *     results 2: arr == { str_a: "Jack and Jill didn't see the well." }
function parse_str(str, array, glue1, glue2){
    glue1 = glue1 || '=';
    glue2 = glue2 || '&';
    
    var array2 = (str+'').split(glue2);
    var array2l = 0, tmp = '', x = 0;

    array2l = array2.length;
    for (x = 0; x<array2l; x++) {
        tmp = array2[x].split(glue1);
        array[unescape(tmp[0])] = unescape(tmp[1]).replace(/[+]/g, ' ');
    }
}

// Convert text to XML DOM
function text2xml(s)
{
    var x, ie = /msie/i.test(navigator.userAgent);
    try
    {
        var p = ie? new ActiveXObject("Microsoft.XMLDOM") : new DOMParser();
        p.async = false;
    }
    catch(e)
    {
        throw new Error("XML Parser could not be instantiated")
    };

    try
    {
        if(ie) x = p.loadXML(s)? p : false;
        else x = p.parseFromString(s, "text/xml");
    }
    catch(e)
    {
        throw new Error("Error parsing XML string")
    };

    return x;
};




// TODO LockeVN: I dont know is it really needed?
function html_entity_decode(str)
{
  var ta = document.createElement("textarea");
  ta.innerHTML = str.replace(/</g,"&lt;").replace(/>/g,"&gt;").replace(/\0/g, '0').replace(/\\/g, '');
  return ta.value;
}


// TODO: remove this function
function processUrl()
{
    var strLocation = location.href;
    var strUrl = strLocation.toString();
    var strSplit = strUrl.split('#');
    return strSplit;
}


// TODO: remove this function if not needed
// Read a page's GET URL variables and return them as an associative array.
function getUrlVars()
{
    var vars = [];
    var hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');

    for(var i = 0; i < hashes.length; i++)
    {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }

    return vars;
}




// LockeVN: actually, I try some ajax call without this function, and everything is normal
function URLEncode (clearString)
{
  var output = '';
  var x = 0;

  clearString = clearString.toString();
  var regex = /(^[a-zA-Z0-9_.]*)/;

  while (x < clearString.length)
  {
    var match = regex.exec(clearString.substr(x));
    if (match != null && match.length > 1 && match[1] != '')
    {
        output += match[1];
        x += match[1].length;
    }
    else
    {
      if (clearString[x] == ' ')
        output += '+';
      else {
        var charCode = clearString.charCodeAt(x);
        var hexVal = charCode.toString(16);
        output += '%' + ( hexVal.length < 2 ? '0' : '' ) + hexVal.toUpperCase();
      }
      x++;
    }
  }

  return output;
}



function htmlspecialchars (string, quote_style) {
    // http://kevin.vanzonneveld.net
    // *     example 1: htmlspecialchars("<a href='test'>Test</a>", 'ENT_QUOTES');
    // *     returns 1: '&lt;a href=&#039;test&#039;&gt;Test&lt;/a&gt;'

    var histogram = {}, symbol = '', tmp_str = '', entity = '';
    tmp_str = string.toString();

    if (false === (histogram = get_html_translation_table('HTML_SPECIALCHARS', quote_style))) {
        return false;
    }

    for (symbol in histogram)
    {
        entity = histogram[symbol];
        tmp_str = tmp_str.split(symbol).join(entity);
    }

    return tmp_str;
}



function get_html_translation_table(table, quote_style) {
    // http://kevin.vanzonneveld.net
    // *     example 1: get_html_translation_table('HTML_SPECIALCHARS');
    // *     returns 1: {'"': '&quot;', '&': '&amp;', '<': '&lt;', '>': '&gt;'}

    var entities = {}, histogram = {}, decimal = 0, symbol = '';
    var constMappingTable = {}, constMappingQuoteStyle = {};
    var useTable = {}, useQuoteStyle = {};

    useTable      = (table ? table.toUpperCase() : 'HTML_SPECIALCHARS');
    useQuoteStyle = (quote_style ? quote_style.toUpperCase() : 'ENT_COMPAT');

    // Translate arguments
    constMappingTable[0]      = 'HTML_SPECIALCHARS';
    constMappingTable[1]      = 'HTML_ENTITIES';
    constMappingQuoteStyle[0] = 'ENT_NOQUOTES';
    constMappingQuoteStyle[2] = 'ENT_COMPAT';
    constMappingQuoteStyle[3] = 'ENT_QUOTES';

    // Map numbers to strings for compatibilty with PHP constants
    if (!isNaN(useTable)) {
        useTable = constMappingTable[useTable];
    }
    if (!isNaN(useQuoteStyle)) {
        useQuoteStyle = constMappingQuoteStyle[useQuoteStyle];
    }

    if (useQuoteStyle != 'ENT_NOQUOTES') {
        entities['34'] = '&quot;';
    }

    if (useQuoteStyle == 'ENT_QUOTES') {
        entities['39'] = '&#039;';
    }

    if (useTable == 'HTML_SPECIALCHARS') {
        // ascii decimals for better compatibility
        entities['38'] = '&amp;';
        entities['60'] = '&lt;';
        entities['62'] = '&gt;';
    } else if (useTable == 'HTML_ENTITIES') {
        // ascii decimals for better compatibility
      entities['38']  = '&amp;';
      entities['60']  = '&lt;';
      entities['62']  = '&gt;';
      entities['160'] = '&nbsp;';
      entities['161'] = '&iexcl;';
      entities['162'] = '&cent;';
      entities['163'] = '&pound;';
      entities['164'] = '&curren;';
      entities['165'] = '&yen;';
      entities['166'] = '&brvbar;';
      entities['167'] = '&sect;';
      entities['168'] = '&uml;';
      entities['169'] = '&copy;';
      entities['170'] = '&ordf;';
      entities['171'] = '&laquo;';
      entities['172'] = '&not;';
      entities['173'] = '&shy;';
      entities['174'] = '&reg;';
      entities['175'] = '&macr;';
      entities['176'] = '&deg;';
      entities['177'] = '&plusmn;';
      entities['178'] = '&sup2;';
      entities['179'] = '&sup3;';
      entities['180'] = '&acute;';
      entities['181'] = '&micro;';
      entities['182'] = '&para;';
      entities['183'] = '&middot;';
      entities['184'] = '&cedil;';
      entities['185'] = '&sup1;';
      entities['186'] = '&ordm;';
      entities['187'] = '&raquo;';
      entities['188'] = '&frac14;';
      entities['189'] = '&frac12;';
      entities['190'] = '&frac34;';
      entities['191'] = '&iquest;';
      entities['192'] = '&Agrave;';
      entities['193'] = '&Aacute;';
      entities['194'] = '&Acirc;';
      entities['195'] = '&Atilde;';
      entities['196'] = '&Auml;';
      entities['197'] = '&Aring;';
      entities['198'] = '&AElig;';
      entities['199'] = '&Ccedil;';
      entities['200'] = '&Egrave;';
      entities['201'] = '&Eacute;';
      entities['202'] = '&Ecirc;';
      entities['203'] = '&Euml;';
      entities['204'] = '&Igrave;';
      entities['205'] = '&Iacute;';
      entities['206'] = '&Icirc;';
      entities['207'] = '&Iuml;';
      entities['208'] = '&ETH;';
      entities['209'] = '&Ntilde;';
      entities['210'] = '&Ograve;';
      entities['211'] = '&Oacute;';
      entities['212'] = '&Ocirc;';
      entities['213'] = '&Otilde;';
      entities['214'] = '&Ouml;';
      entities['215'] = '&times;';
      entities['216'] = '&Oslash;';
      entities['217'] = '&Ugrave;';
      entities['218'] = '&Uacute;';
      entities['219'] = '&Ucirc;';
      entities['220'] = '&Uuml;';
      entities['221'] = '&Yacute;';
      entities['222'] = '&THORN;';
      entities['223'] = '&szlig;';
      entities['224'] = '&agrave;';
      entities['225'] = '&aacute;';
      entities['226'] = '&acirc;';
      entities['227'] = '&atilde;';
      entities['228'] = '&auml;';
      entities['229'] = '&aring;';
      entities['230'] = '&aelig;';
      entities['231'] = '&ccedil;';
      entities['232'] = '&egrave;';
      entities['233'] = '&eacute;';
      entities['234'] = '&ecirc;';
      entities['235'] = '&euml;';
      entities['236'] = '&igrave;';
      entities['237'] = '&iacute;';
      entities['238'] = '&icirc;';
      entities['239'] = '&iuml;';
      entities['240'] = '&eth;';
      entities['241'] = '&ntilde;';
      entities['242'] = '&ograve;';
      entities['243'] = '&oacute;';
      entities['244'] = '&ocirc;';
      entities['245'] = '&otilde;';
      entities['246'] = '&ouml;';
      entities['247'] = '&divide;';
      entities['248'] = '&oslash;';
      entities['249'] = '&ugrave;';
      entities['250'] = '&uacute;';
      entities['251'] = '&ucirc;';
      entities['252'] = '&uuml;';
      entities['253'] = '&yacute;';
      entities['254'] = '&thorn;';
      entities['255'] = '&yuml;';
    } else {
        throw Error("Table: "+useTable+' not supported');
        return false;
    }

    // ascii decimals to real symbols
    for (decimal in entities) {
        symbol = String.fromCharCode(decimal)
        histogram[symbol] = entities[decimal];
    }

    return histogram;
}


/**
give /message/user/read.php?abc... only, no need the API address, no need the transport proxy.
*/
function MakeProxiedURLToQAPI(url)
{
    var arr = url.split("?");
    var proxyurl = '/Action/transport.php?url=' +  QAPI_URL + arr[0] + '&' + arr[1];
    return proxyurl;
}

function ExecuteURLSync(url)
{
    var result = $.ajax({
        url: url,
        processData: false,
        async: false
    }).responseText;
    return result;
}


/**
give me XML 
@return object {stat,id,info}
*/
function ParseXML_ReturnCommandStatus(data)
{   
    var stat = $(data).attr('stat');
    var id = $(data).find('id').text();
    var info = $(data).find('info').text();
        
    var retobject = {
        stat: stat,
       id: id,
       info: info
    }; 
    return retobject;
}



/**
give /message/user/read.php?abc... only. 
@return object {stat,id,info}
*/
function ExecuteURLSync_ReturnCommandStatus(url)
{
    var proxyurl = MakeProxiedURLToQAPI(url);    
    var data = ExecuteURLSync(proxyurl);   
    
    return ParseXML_ReturnCommandStatus(data);
}

/**
give /message/user/read.php?abc... only. 
@return object {stat,id,info}
*/
function ExecuteURLSync_ReturnXML(url)
{
    var proxyurl = MakeProxiedURLToQAPI(url);    
    var data = ExecuteURLSync(proxyurl);       
    
    return data;
}




/************            UI             *********/
/**
block whole page with waiting message
*/
function waiting(msg)
{
	if(typeof msg == 'undefined' || msg == '')
    {
		msg = 'Vui lòng chờ trong giây lát ...'
    }

	$.blockUI({
        css: {
            border: 'none',
            padding: '15px',
            backgroundColor: '#000',
            '-webkit-border-radius': '10px',
            '-moz-border-radius': '10px',
            opacity: '.5',
            fontSize:'14px',
            fontWeight:'bold',
            fontFamily:'tahoma, verdana',
            color: '#FFF'
        },
        message: msg
	});
}


/**
*/
function show_notice_msg(message, title, icon)
{   
    var $m = $('<div class="growlUI"></div>');
    if (title) $m.append('<h1>'+title+'</h1>');
    if (message) $m.append('<h2>'+message+'</h2>');
    
    var icon = "url(/image/icon.check.png) no-repeat 10px 10px";
    $("div.growlUI").css("background" , icon);
    	    
    $.blockUI({ 
        message: $m, 
        fadeIn: 700, 
        fadeOut: 1000, 
        timeout: 4000, 
        showOverlay: false, 
        centerX: true, 
        centerY: true, 
        css: { 
            width: '500px', 
//            top: '10px', 
//            left: '', 
//            right: '100px', 
            border: 'none', 
            padding: '5px',
            backgroundColor: '#000',             
            '-webkit-border-radius': '10px', 
            '-moz-border-radius': '10px', 
            opacity: '.7', 
            color: '#fff' 
        } 
    });  
}
