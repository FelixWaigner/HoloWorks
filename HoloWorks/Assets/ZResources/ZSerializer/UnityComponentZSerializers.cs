
using UnityEngine;
using System.Linq;
using System.Collections.Generic;
namespace ZSerializer {

[System.Serializable]
public sealed class AudioSourceZSerializer : ZSerializer.Internal.ZSerializer {
    public System.Single volume;
    public System.Single pitch;
    public System.Single time;
    public System.Int32 timeSamples;
    public UnityEngine.AudioClip clip;
    public UnityEngine.Audio.AudioMixerGroup outputAudioMixerGroup;
    public UnityEngine.GamepadSpeakerOutputType gamepadSpeakerOutputType;
    public System.Boolean loop;
    public System.Boolean ignoreListenerVolume;
    public System.Boolean playOnAwake;
    public System.Boolean ignoreListenerPause;
    public UnityEngine.AudioVelocityUpdateMode velocityUpdateMode;
    public System.Single panStereo;
    public System.Single spatialBlend;
    public System.Boolean spatialize;
    public System.Boolean spatializePostEffects;
    public System.Single reverbZoneMix;
    public System.Boolean bypassEffects;
    public System.Boolean bypassListenerEffects;
    public System.Boolean bypassReverbZones;
    public System.Single dopplerLevel;
    public System.Single spread;
    public System.Int32 priority;
    public System.Boolean mute;
    public System.Single minDistance;
    public System.Single maxDistance;
    public UnityEngine.AudioRolloffMode rolloffMode;
    public System.Boolean enabled;
    public UnityEngine.HideFlags hideFlags;
    public AudioSourceZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.AudioSource;
        volume = instance.volume;
        pitch = instance.pitch;
        time = instance.time;
        timeSamples = instance.timeSamples;
        clip = instance.clip;
        outputAudioMixerGroup = instance.outputAudioMixerGroup;
        gamepadSpeakerOutputType = instance.gamepadSpeakerOutputType;
        loop = instance.loop;
        ignoreListenerVolume = instance.ignoreListenerVolume;
        playOnAwake = instance.playOnAwake;
        ignoreListenerPause = instance.ignoreListenerPause;
        velocityUpdateMode = instance.velocityUpdateMode;
        panStereo = instance.panStereo;
        spatialBlend = instance.spatialBlend;
        spatialize = instance.spatialize;
        spatializePostEffects = instance.spatializePostEffects;
        reverbZoneMix = instance.reverbZoneMix;
        bypassEffects = instance.bypassEffects;
        bypassListenerEffects = instance.bypassListenerEffects;
        bypassReverbZones = instance.bypassReverbZones;
        dopplerLevel = instance.dopplerLevel;
        spread = instance.spread;
        priority = instance.priority;
        mute = instance.mute;
        minDistance = instance.minDistance;
        maxDistance = instance.maxDistance;
        rolloffMode = instance.rolloffMode;
        enabled = instance.enabled;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.AudioSource))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.AudioSource)component;
        instance.volume = volume;
        instance.pitch = pitch;
        instance.time = time;
        instance.timeSamples = timeSamples;
        instance.clip = clip;
        instance.outputAudioMixerGroup = outputAudioMixerGroup;
        instance.gamepadSpeakerOutputType = gamepadSpeakerOutputType;
        instance.loop = loop;
        instance.ignoreListenerVolume = ignoreListenerVolume;
        instance.playOnAwake = playOnAwake;
        instance.ignoreListenerPause = ignoreListenerPause;
        instance.velocityUpdateMode = velocityUpdateMode;
        instance.panStereo = panStereo;
        instance.spatialBlend = spatialBlend;
        instance.spatialize = spatialize;
        instance.spatializePostEffects = spatializePostEffects;
        instance.reverbZoneMix = reverbZoneMix;
        instance.bypassEffects = bypassEffects;
        instance.bypassListenerEffects = bypassListenerEffects;
        instance.bypassReverbZones = bypassReverbZones;
        instance.dopplerLevel = dopplerLevel;
        instance.spread = spread;
        instance.priority = priority;
        instance.mute = mute;
        instance.minDistance = minDistance;
        instance.maxDistance = maxDistance;
        instance.rolloffMode = rolloffMode;
        instance.enabled = enabled;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.AudioSource))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class TransformZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.Vector3 position;
    public UnityEngine.Vector3 localPosition;
    public UnityEngine.Vector3 eulerAngles;
    public UnityEngine.Vector3 localEulerAngles;
    public UnityEngine.Vector3 right;
    public UnityEngine.Vector3 up;
    public UnityEngine.Vector3 forward;
    public UnityEngine.Quaternion rotation;
    public UnityEngine.Quaternion localRotation;
    public UnityEngine.Vector3 localScale;
    public UnityEngine.Transform parent;
    public System.Boolean hasChanged;
    public System.Int32 hierarchyCapacity;
    public UnityEngine.HideFlags hideFlags;
    public TransformZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.Transform;
        position = instance.position;
        localPosition = instance.localPosition;
        eulerAngles = instance.eulerAngles;
        localEulerAngles = instance.localEulerAngles;
        right = instance.right;
        up = instance.up;
        forward = instance.forward;
        rotation = instance.rotation;
        localRotation = instance.localRotation;
        localScale = instance.localScale;
        parent = instance.parent;
        hasChanged = instance.hasChanged;
        hierarchyCapacity = instance.hierarchyCapacity;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.Transform))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.Transform)component;
        instance.position = position;
        instance.localPosition = localPosition;
        instance.eulerAngles = eulerAngles;
        instance.localEulerAngles = localEulerAngles;
        instance.right = right;
        instance.up = up;
        instance.forward = forward;
        instance.rotation = rotation;
        instance.localRotation = localRotation;
        instance.localScale = localScale;
        instance.parent = parent;
        instance.hasChanged = hasChanged;
        instance.hierarchyCapacity = hierarchyCapacity;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.Transform))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class HingeJoint2DZSerializer : ZSerializer.Internal.ZSerializer {
    public System.Boolean useMotor;
    public System.Boolean useLimits;
    public UnityEngine.JointMotor2D motor;
    public UnityEngine.JointAngleLimits2D limits;
    public UnityEngine.Vector2 anchor;
    public UnityEngine.Vector2 connectedAnchor;
    public System.Boolean autoConfigureConnectedAnchor;
    public UnityEngine.Rigidbody2D connectedBody;
    public System.Boolean enableCollision;
    public System.Single breakForce;
    public System.Single breakTorque;
    public System.Boolean enabled;
    public UnityEngine.HideFlags hideFlags;
    public Vector2 serializableLimits;
    public Vector2 serializableMotor;
    public HingeJoint2DZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.HingeJoint2D;
        useMotor = instance.useMotor;
        useLimits = instance.useLimits;
        motor = instance.motor;
        limits = instance.limits;
        anchor = instance.anchor;
        connectedAnchor = instance.connectedAnchor;
        autoConfigureConnectedAnchor = instance.autoConfigureConnectedAnchor;
        connectedBody = instance.connectedBody;
        enableCollision = instance.enableCollision;
        breakForce = instance.breakForce;
        breakTorque = instance.breakTorque;
        enabled = instance.enabled;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.HingeJoint2D))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.HingeJoint2D)component;
        instance.useMotor = useMotor;
        instance.useLimits = useLimits;
        instance.motor = motor;
        instance.limits = limits;
        instance.anchor = anchor;
        instance.connectedAnchor = connectedAnchor;
        instance.autoConfigureConnectedAnchor = autoConfigureConnectedAnchor;
        instance.connectedBody = connectedBody;
        instance.enableCollision = enableCollision;
        instance.breakForce = breakForce;
        instance.breakTorque = breakTorque;
        instance.enabled = enabled;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.HingeJoint2D))?.OnDeserialize?.Invoke(this, instance);
    }
}
}