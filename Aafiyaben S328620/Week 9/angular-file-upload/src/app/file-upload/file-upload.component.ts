fileToUpload: File | null = null;
handleFileInput(files: FileList) {
  this.fileToUpload = files.item(0);
}