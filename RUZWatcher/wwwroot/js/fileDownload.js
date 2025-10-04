﻿window.downloadFile = function (filename, base64Content) {
    const linkSource = `data:application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;base64,${base64Content}`;
    const downloadLink = document.createElement("a");

    downloadLink.href = linkSource;
    downloadLink.download = filename;
    downloadLink.click();
    downloadLink.remove();
};