pushd bpqmanager
dotnet publish --runtime linux-arm64 --self-contained /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true -o ../publish
popd