platform :ios, '12.0'

target 'UnityFramework' do
   pod 'AffiseInternal', '1.6.53'
   
end

target 'Unity-iPhone' do
end

use_frameworks! :linkage => :static
