# Azure Pipelines Tools VSCode Extension

This is a minimal Azure Pipelines Extension, the first vscode Extension which can Validate and Expand Azure Pipeline YAML files locally without any REST service.

![Validate Azure Pipelines via ContextMenu](https://raw.githubusercontent.com/ChristopherHX/runner.server/main/docs/azure-pipelines/images/validate-azure-pipeline-via-contextmenu.gif)
![Expand Azure Pipelines via ContextMenu](https://raw.githubusercontent.com/ChristopherHX/runner.server/main/docs/azure-pipelines/images/expand-azure-pipeline-via-contextmenu.gif)

## Features

### Remote Template References

The `azure-pipelines-vscode-ext.repositories` settings maps the external Repositories to local or remote folders.

Syntax `[<owner>/]<repo>@<ref>=<uri>` per line. `<uri>` can be formed like `file:///<folder>` (raw file paths are not supported (yet?)), `vscode-vfs://github/<owner>/<repository>` and `vscode-vfs://azurerepos/<owner>/<project>/<repository>`

### Validate Azure Pipeline

`> Validate Azure Pipeline`

This command tries to evaluate your current open Azure Pipeline including templates and notifies you about the result.

_Once this extension has been activated by any command, you can validate your pipeline via a statusbar button with the same name on all yaml or azure-pipelines documents_

### Expand Azure Pipeline

`> Expand Azure Pipeline`

This command tries to evaluate your current open Azure Pipeline including templates and show the result in a new document, which you can save or validate via the official api.

### Azure Pipelines Linter Task

You can configure parameters, variables, repositories per task. You can define multiple tasks with different parameters and variables or filenames to catch errors on changing template files as early as possible.

`.vscode/tasks.json`
```jsonc
{
    "version": "2.0.0",
    "tasks": [
        {
            "type": "azure-pipelines-vscode-ext",
            "label": "test",
            "program": "${workspaceFolder}/azure-pipeline.yml",
            "repositories": {
                "myrepo@windows": "file:///C:/AzurePipelines/myrepo",
                "myrepo@unix": "file:///AzurePipelines/myrepo",
                "myrepo@github": "vscode-vfs://github/AzurePipelines/myrepo", // Only default branch, url doesn't accept readable ref
                "myrepo@azure": "vscode-vfs://azurerepos/AzurePipelines/myrepo/myrepo" // Only default branch, url doesn't accept readable ref
            },
            "parameters": {
                "booleanparam": true,
                "numberparam": 12,
                "stringparam": "Hello World",
                "objectparam": {
                    "booleanparam": true,
                    "numberparam": 12,
                    "stringparam": "Hello World",
                },
                "arrayparam": [
                    true,
                    12,
                    "Hello World"
                ]
            },
            "variables": {
                "system.debug": "true"
            },
            "preview": true, // Show a preview of the expanded yaml
            "watch": true    // Watch for yaml file changes
        },
        {
            "type": "azure-pipelines-vscode-ext",
            "label": "test2",
            "program": "${workspaceFolder}/azure-pipeline.yml",
            "repositories": {
                "myrepo@windows": "file:///C:/AzurePipelines/myrepo",
                "myrepo@unix": "file:///AzurePipelines/myrepo",
                "myrepo@github": "vscode-vfs://github/AzurePipelines/myrepo", // Only default branch, url doesn't accept readable ref
                "myrepo@azure": "vscode-vfs://azurerepos/AzurePipelines/myrepo/myrepo" // Only default branch, url doesn't accept readable ref
            },
            "parameters": {
                "booleanparam": true,
                "numberparam": 12,
                "stringparam": "Hello World",
                "objectparam": {
                    "booleanparam": true,
                    "numberparam": 12,
                    "stringparam": "Hello World",
                },
                "arrayparam": [
                    true,
                    12,
                    "Hello World"
                ]
            },
            "variables": {
                "system.debug": "true"
            },
            "watch": true    // Watch for yaml file changes
        }
    ]   
}
```
Sample Pipeline which dumps the parameters object (legacy parameters syntax)
```yaml
parameters:
  booleanparam:
  numberparam:
  stringparam:
  objectparam:
  arrayparam:
steps:
- script: echo '${{ converttojson(parameters) }}'
- script: echo '${{ converttojson(variables) }}'
```

### Azure Pipelines Debug Adapter

![Demo](https://raw.githubusercontent.com/ChristopherHX/runner.server/main/docs/azure-pipelines/images/demo.gif)

Sample Debugging configuration
`.vscode/launch.json`
```jsonc
{
    "type": "azure-pipelines-vscode-ext",
    "request": "launch",
    "name": "Test Pipeline (watch)",
    "program": "${workspaceFolder}/azure-pipeline.yml",
    "repositories": {
        "myrepo@windows": "file:///C:/AzurePipelines/myrepo",
        "myrepo@unix": "file:///AzurePipelines/myrepo",
        "myrepo@github": "vscode-vfs://github/AzurePipelines/myrepo", // Only default branch, url doesn't accept readable ref
        "myrepo@azure": "vscode-vfs://azurerepos/AzurePipelines/myrepo/myrepo" // Only default branch, url doesn't accept readable ref
    },
    "parameters": {
        "booleanparam": true,
        "numberparam": 12,
        "stringparam": "Hello World",
        "objectparam": {
            "booleanparam": true,
            "numberparam": 12,
            "stringparam": "Hello World",
        },
        "arrayparam": [
            true,
            12,
            "Hello World"
        ]
    },
    "variables": {
        "system.debug": "true"
    },
    "watch": true,
    "preview": true
}
```

Sample Pipeline which dumps the parameters object (legacy parameters syntax)
```yaml
parameters:
  booleanparam:
  numberparam:
  stringparam:
  objectparam:
  arrayparam:
steps:
- script: echo '${{ converttojson(parameters) }}'
- script: echo '${{ converttojson(variables) }}'
```

Output of the Sample Pipeline
```yaml
stages:
- stage: 
  jobs:
  - job: 
    steps:
    - task: CmdLine@2
      inputs:
        script: |-
          echo '{
            "booleanparam": true,
            "numberparam": 12,
            "stringparam": "Hello World",
            "objectparam": {
              "booleanparam": true,
              "numberparam": 12,
              "stringparam": "Hello World"
            },
            "arrayparam": [
              true,
              12,
              "Hello World"
            ]
          }'
    - task: CmdLine@2
      inputs:
        script: |-
          echo '{
            "system.debug": "true"
          }'
```

## Pros
- Make changes in multiple dependent template files and show a live preview on save
- Everything is done locally
- You can run template files with the same template engine locally using the Runner.Client tool using the official Azure Pipelines Agent
- Fast feedback
- Less trial and error commits
- You can help by reporting bugs
- It's fully Open Source under the MIT license

## Cons
- May contain different bugs than the Azure Pipelines Service
- You could self-host Azure Devops Server and commit your changes to your local system, may have license implications with more accurate results of the template engine
- May not have feature parity with Azure Pipelines
- Missing predefined Variables, feel free to add them manually as needed

## Available in the VSCode Marketplace

[Azure Pipelines Tools](https://marketplace.visualstudio.com/items?itemName=christopherhx.azure-pipelines-vscode-ext)

## Contributing

I'm happy to review Pull Requests to this repository, including Documentation / Readme updates or suggesting a new icon for the vscode extension.

### Running the Dev Extension

```sh
npm install
dotnet workload install wasm-tools
npm run build
```

- Run vscode target "Run azure-pipelines-vscode-ext Extension" to test it

### Nightly VSIX File
- https://christopherhx.github.io/runner.server/azure-pipelines-vscode-ext/azure-pipelines-vscode-ext.vsix
- https://christopherhx.github.io/runner.server/azure-pipelines-vscode-ext/azure-pipelines-vscode-ext-pre-release.vsix
  - same as first one, but marked as pre-release if you install it
