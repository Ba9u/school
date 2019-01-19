<?php
$tempfile = $_FILES['fname']['tmp_name'];
$filename = './' . $_FILES['fname']['name'];
 
if (is_uploaded_file($tempfile)) {
    if ( move_uploaded_file($tempfile , $filename )) {
	echo $filename . "をアップロードしました。";
    } else {
        echo "ファイルをアップロードできません。";
    }
} else {
    echo "ファイルが選択されていません。";
} 
$filename=$_FILES['fname']['name'];
$img = base64_encode(file_get_contents($filename));
$jsonstr=json_encode($img);
$fullPath =
      'python ./cgi-bin/call_from_php.py '.$base64_string;
    exec($fullPath, $outpara);
?>