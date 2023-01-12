mergeInto(LibraryManager.library,
{
	openAd: function() // Called by unity from Create Ad Button
	{
		// call function in index
		 adBreak({
        	type: 'next',  // ad shows at start of next level
			name: 'restart-game',
      		});

		
		
	},

	focusReturn: function() // Called by unity from Create Ad Button
	{
		window.focus();
	},

	Alert: function()
	{
		window.alert("Unity to JS Alert!");
	},

	AlertParam: function(param)
	{
		window.alert(Pointer_stringify(param));
	},

	GetInt: function()
	{
		var num = 100;
		return num;
	},

	GetString: function()
	{
		var str = "This is string returned by Js";
		var bufferSize = lengthByteUTF8(str) + 1;
		var buffer = _malloc(bufferSize);
		stringToUTF8(str, buffer, bufferSize);
		return buffer;
	},

	OpenTab : function(url)
    {
        url = Pointer_stringify(url);
        window.open(url,'_blank');
    },

});