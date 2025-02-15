local UserInputService = game:GetService("UserInputService")
local Players = game:GetService("Players")

local player = Players.LocalPlayer
local character = player.Character or player.CharacterAdded:Wait()

local isInvisible = false

local function toggleInvisibility()
    if not character then return end
    
    isInvisible = not isInvisible -- Toggle state

    for _, part in pairs(character:GetDescendants()) do
        if part:IsA("BasePart") and part.Name ~= "HumanoidRootPart" then
            part.Transparency = isInvisible and 1 or 0 -- Hide or show
            part.CanCollide = not isInvisible -- Disable collisions when invisible
        end
    end
end

-- Detect key press
UserInputService.InputBegan:Connect(function(input, gameProcessed)
    if gameProcessed then return end -- Ignore UI interactions
    if input.KeyCode == Enum.KeyCode.E then
        toggleInvisibility()
    end
end)
