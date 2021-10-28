/**
 * @license Copyright (c) 2003-2015, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';

	config.syntaxhighlight_lang = 'c#';
	config.syntaxhighlight_hideControls = true;
	config.language = 'vi';
	config.filebrowserBrowseUrl = '/Assets/js/plugins/ckfinder/ckfinder.html';
	config.filebrowserImageBrowseUrl = '/Assets/js/plugins/ckfinder.html?Type=Images';
	config.filebrowserFlashBrowseUrl = '/Assets/js/plugins/ckfinder.html?Type=Flash';
	config.filebrowserUploadUrl = '/Assets/js/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
	config.filebrowserImageUploadUrl = '/Data';
	config.filebrowserFlashUploadUrl = '/Assets/js/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

	CKFinder.setupCKEditor(null, '/Assets/js/plugins/ckfinder/');
};
