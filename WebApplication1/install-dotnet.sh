#!/bin/bash

# Install .NET SDK (latest LTS version)
curl -fsSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --channel LTS

# Add .NET to PATH
export DOTNET_ROOT=$HOME/.dotnet
export PATH=$HOME/.dotnet:$HOME/.dotnet/tools:$PATH

# Verify installation
dotnet --version
