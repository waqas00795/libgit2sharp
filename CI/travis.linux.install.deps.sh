#!/bin/bash
set -ev

MONO_VER=3.6.0

sudo sh -c "echo 'deb http://download.opensuse.org/repositories/home:/tpokorra:/mono/xUbuntu_12.04/ /' >> /etc/apt/sources.list.d/mono-opt.list"

curl http://download.opensuse.org/repositories/home:/tpokorra:/mono/xUbuntu_12.04/Release.key | sudo apt-key add -

sudo apt-get update
sudo apt-get install mono-opt=${MONO_VER} cmake
