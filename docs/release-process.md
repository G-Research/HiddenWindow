# Release Process

1. For this project, most of the versioning is handled by Nerdbank.GitVersioning.
2. Head over to the last successful CI build logs on the main branch and retrieve the current build version used (X.X.X).
3. Then, draft a new [GitHub Release](https://github.com/G-Research/HiddenWindow/releases) with a list of changes contained in the new version from the [CHANGELOG](https://github.com/G-Research/HiddenWindow/blob/main/CHANGELOG.md).
4. When the draft release is ready, publish it from the GitHub web UI. You can either have GitHub create a new tag for you from the GitHub Release page or push the tag yourself beforehand. It should use the following format: "vX.X.X".
Be aware, clicking **Publish** will trigger GitHub to push a new tag (as specified in the new Release entry, if not created by you already) which will instruct the CI to build and push a new stable release to NuGet.org.
5. If everything went well, congrats, the new versions should be live on NuGet by now. As a final post-release step, bump the minor version in `version.json` to the next unreleased version number, so that nightly build versioning can benefit.
