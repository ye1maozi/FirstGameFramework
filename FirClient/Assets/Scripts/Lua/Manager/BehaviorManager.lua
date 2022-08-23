
---@class Updater
---@method Update

---@class BehaviorManager
local BehaviorManager = class("BehaviorManager")

function BehaviorManager:Initialize()
    log("BehaviorManager:Initialize")
    self.updaters = {}
    local parent = find('/MainGame/MainCamera')
    self:AddBehaviorScript(parent,"Update")
end

function BehaviorManager:Register(updater)
    log("BehaviorManager:Register")
    table.insert(self.updaters , updater)

end

function BehaviorManager:UnRegister(updater)
    local pos = 0
    for i = 1, #self.updaters do
        if self.updaters[i] == updater then
            pos = i
            break
        end
    end
    if pos ~= 0 then
        table.remove(self.updaters,pos)
    end
end

function BehaviorManager:Update()
    local delta = UnityEngine.Time.deltaTime
    for i, updater in pairs( self.updaters) do
        if updater["Update"] then
            updater["Update"](updater,delta)
        end
    end
end

function BehaviorManager:LateUpdate()
    local delta = UnityEngine.Time.deltaTime
    for i, updater in pairs( self.updaters) do
        if updater["LateUpdate"] then
            updater["LateUpdate"](updater,delta)
        end
    end
end

function BehaviorManager:FixedUpdate()
    local delta = UnityEngine.Time.fixedDeltaTime
    for i, updater in pairs( self.updaters) do
        if updater["FixedUpdate"] then
            updater["FixedUpdate"](updater,delta)
        end
    end
end

function BehaviorManager:OnDestroy()
    for i, updater in pairs( self.updaters) do
        if updater["OnDestroy"] then
            updater["OnDestroy"](updater)
        end
    end
end


local LiveFuncName = {
    "FixedUpdate","Update","LateUpdate","OnDestroy"
}
function BehaviorManager:AddBehaviorScript(obj,scriptname)
    if obj then
        local funcNameTable = {}
        local funcTable = {}
        for _, funcName in pairs(LiveFuncName) do
            local func = self[funcName]
            if func then
                table.insert(funcNameTable,funcName)
                table.insert(funcTable,handler(func,self))
            end
        end
        if #funcNameTable > 0 then
            self.behaviour = LuaHelper.AddLuaBehaviour(obj,scriptname,funcNameTable,funcTable)
            return self.behaviour
        end
    else
        logWarn("obj == null")
    end
end

return BehaviorManager