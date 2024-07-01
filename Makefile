.PHONY: run-mac

run-mac:
	dotnet build -t:Run -f net8.0-maccatalyst
